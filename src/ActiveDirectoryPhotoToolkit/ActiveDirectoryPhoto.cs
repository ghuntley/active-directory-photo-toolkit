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
        public enum Format
        {
            BMP, GIF, JPG, PNG
        }

        public Thumbnail GetThumbnailPhoto(string userName, Format format)
        {
            var principalContext = new PrincipalContext(ContextType.Domain);

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
                    if (user.Properties["thumbnailPhoto"] != null)
                    {
                        //if bitmap just return this...
                        var bytes = user.Properties["thumbnailPhoto"][0] as byte[];

                        //if not bimap do above then do this...
                        using (var inStream = new MemoryStream(bytes))
                        {
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

                                // rewind the memory stream so that it can be exported.
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
                    }
                }
            }
            else
            {
                throw new NoMatchingPrincipalException();
            }

            return null;
        }

        public void SetThumbnailPhoto(string userName, string thumbNailLocation)
        {
           var principalContext = new PrincipalContext(ContextType.Domain);

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
                    //if bitmap just return this...
                    user.Properties["thumbnailPhoto"][0] = bytes;
                    user.CommitChanges();
                }
            }
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail)
        {
            File.WriteAllBytes($"{thumbnail.Name}.{thumbnail.Format}", thumbnail.ThumbnailData);
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail, string location)
        {
            File.WriteAllBytes(Path.Combine(location, $"{thumbnail.Name}.{thumbnail.Format}"), thumbnail.ThumbnailData);
        }
    }
}