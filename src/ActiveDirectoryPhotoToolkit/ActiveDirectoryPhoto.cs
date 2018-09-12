using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;

namespace ActiveDirectoryPhotoToolkit
{
    public class ActiveDirectoryPhoto : IActiveDirectoryPhoto
    {
        private const string FileName = "{thumbnail.Name}.{thumbnail.Format}";

        public enum Format
        {
            BMP, GIF, JPG, PNG
        }

        public Thumbnail GetThumbnailPhoto(string userName, Format format)
        {
            byte[] bytes = null;

            using (var principalContext = new PrincipalContext(ContextType.Domain))
            {
                var userPrincipal = new UserPrincipal(principalContext)
                {
                    SamAccountName = userName
                };

                var principalSearcher = new PrincipalSearcher
                {
                    QueryFilter = userPrincipal
                };

                var result = principalSearcher.FindOne();

                if (result != null)
                {
                    using (var user = result.GetUnderlyingObject() as DirectoryEntry)
                    {
                        bytes = user.Properties["thumbnailPhoto"][0] as byte[];
                    }
                }
            }

            if (bytes != null)
            {
                using (var inStream = new MemoryStream(bytes ?? throw new InvalidOperationException()))
                using (var outStream = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        const int imageQuality = 95;
                        var imageSize = new Size(96, 96);

                        imageFactory.Load(inStream);

                        switch (format)
                        {
                            case Format.JPG:
                                imageFactory.Format(new JpegFormat());
                                break;
                            case Format.PNG:
                                imageFactory.Format(new PngFormat());
                                break;
                            case Format.GIF:
                                imageFactory.Format(new GifFormat());
                                break;
                            case Format.BMP:
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
                        Name = userName,
                        Format = format,
                        ThumbnailData = outStream.ToArray()
                    };

                    return thumbnail;
                }
            }

            return null;
        }

        public void SetThumbnailPhoto(string userName, string thumbNailLocation)
        {
            using (var principalContext = new PrincipalContext(ContextType.Domain))
            {
                var userPrincipal = new UserPrincipal(principalContext)
                {
                    SamAccountName = userName
                };

                var principalSearcher = new PrincipalSearcher
                {
                    QueryFilter = userPrincipal
                };

                var result = principalSearcher.FindOne();

                if (result != null)
                {
                    var bytes = File.ReadAllBytes(thumbNailLocation);

                    using (var user = result.GetUnderlyingObject() as DirectoryEntry)
                    {
                        user.Properties["thumbnailPhoto"][0] = bytes;
                        user.CommitChanges();
                    }
                }
            }
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail)
        {
            File.WriteAllBytes(string.Format(FileName), thumbnail.ThumbnailData);
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail, string location)
        {
            File.WriteAllBytes(Path.Combine(location, string.Format(FileName)), thumbnail.ThumbnailData);
        }
    }
}