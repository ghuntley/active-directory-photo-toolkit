using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;
using ActiveDirectoryPhotoToolkit.ExceptionClasses;

namespace ActiveDirectoryPhotoToolkit
{
    public class ActiveDirectoryPhoto : IActiveDirectoryPhoto
    {
        public enum Format
        {
            Bmp,
            Gif,
            Jpg,
            Png
        };

        public void RemoveThumnnailPhoto(string username)
        {
            var result = GetUser(username);

            if (result == null) return;

            using (var user = result.GetUnderlyingObject() as DirectoryEntry)
            {
                user.Properties["thumbnailPhoto"].Clear();
                user.CommitChanges();
            }
        }

        public Thumbnail GetThumbnailPhoto(string username, Format format)
        {
            byte[] bytes;

            var result = GetUser(username);

            if (result == null) return null;

            using (var user = result.GetUnderlyingObject() as DirectoryEntry)
            {
                bytes = user.Properties["thumbnailPhoto"].Value as byte[];
            }

            if (bytes == null) return null;

            using (var inStream = new MemoryStream(bytes))
            using (var outStream = new MemoryStream())
            {
                using (var imageFactory = new ImageFactory())
                {
                    const int imageQuality = 95;
                    var imageSize = new Size(96, 96);

                    imageFactory.Load(inStream);

                    switch (format)
                    {
                        case Format.Jpg:
                            imageFactory.Format(new JpegFormat());
                            break;
                        case Format.Png:
                            imageFactory.Format(new PngFormat());
                            break;
                        case Format.Gif:
                            imageFactory.Format(new GifFormat());
                            break;
                        case Format.Bmp:
                            imageFactory.Format(new BitmapFormat());
                            break;
                    }

                    imageFactory.Resize(imageSize);
                    imageFactory.Quality(imageQuality);
                    imageFactory.Save(outStream);
                }

                outStream.Position = 0;

                var thumbnail = new Thumbnail()
                {
                    Name = username,
                    Format = format,
                    ThumbnailData = outStream.ToArray()
                };

                return thumbnail;
            }
        }

        public void SetThumbnailPhoto(string username, string thumbNailLocation)
        {
            var result = GetUser(username);

            if (result == null) return;

            var image = Image.FromFile(thumbNailLocation);

            if (image.Height <= 200 && image.Width <= 200)
            {
                var bytes = File.ReadAllBytes(thumbNailLocation);

                if (bytes.Length <= 100000)
                {
                    using (var user = result.GetUnderlyingObject() as DirectoryEntry)
                    {
                        user.Properties["thumbnailPhoto"].Clear();
                        user.Properties["thumbnailPhoto"].Add(bytes);
                        user.CommitChanges();
                    }
                }
                else
                {
                    throw new PhotoTooLargeException();
                }
            }
            else
            {
                throw new PhotoResolutionInvalidException();
            }
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail)
        {
            File.WriteAllBytes(thumbnail.Name + "." + thumbnail.Format, thumbnail.ThumbnailData);
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail, string location)
        {
            File.WriteAllBytes(Path.Combine(location, thumbnail.Name + "." + thumbnail.Format), thumbnail.ThumbnailData);
        }

        private static Principal GetUser(string username)
        {
            using (var principalContext = new PrincipalContext(ContextType.Domain))
            {
                var userPrincipal = new UserPrincipal(principalContext)
                {
                    SamAccountName = username
                };

                var principalSearcher = new PrincipalSearcher
                {
                    QueryFilter = userPrincipal
                };

                var user = principalSearcher.FindOne();

                return user;
            }
        }
    }
}