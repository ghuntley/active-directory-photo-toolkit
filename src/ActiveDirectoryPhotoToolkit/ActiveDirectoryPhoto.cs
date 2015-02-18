using System;
using System.Diagnostics.Contracts;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ActiveDirectoryPhotoToolkit
{
    public class ActiveDirectoryPhoto : IActiveDirectoryPhoto
    {
        /// <example>
        ///     var directoryEntry = new DirectoryEntry("LDAP://contoso.com");
        ///     var adPhoto = new ActiveDirectoryPhoto(directoryEntry);
        ///     var jpeg = adPhoto.GetThumbnailPhotoAsJpeg("ghuntley");
        ///     var bitmap = adPhoto.GetThumbnailPhotoAsBitmap("ghuntley");
        /// </example>
        /// <param name="directoryEntry"></param>
        public ActiveDirectoryPhoto(DirectoryEntry directoryEntry)
        {
            Contract.Requires(directoryEntry != null);
            Contract.Ensures(DirectoryEntry == directoryEntry);

            DirectoryEntry = directoryEntry;
        }

        public DirectoryEntry DirectoryEntry { get; private set; }

        /// <summary>
        ///     Returns a Bitmap byte[] of the Active Directory thumbnailPhoto for the specified username.
        /// </summary>
        /// <param name="userName"></param>
        /// -
        /// <returns></returns>
        public Byte[] GetThumbnailPhotoAsBitmap(string userName)
        {
            var directorySearcher = new DirectorySearcher(DirectoryEntry)
            {
                Filter = string.Format("(&(SAMAccountName={0}))", userName)
            };

            SearchResult user = directorySearcher.FindOne();

            var bytes = user.Properties["thumbnailPhoto"][0] as byte[];

            return bytes;
        }

        /// <summary>
        ///     Returns a 96 (w) x 96 (h) JPEG image as byte[] of the Active Directory thumbnailPhoto for the specified username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Byte[] GetThumbnailPhotoAsJpeg(string userName)
        {
            byte[] bytes = GetThumbnailPhotoAsBitmap(userName);

            const int imageQuality = 95;
            var imageSize = new Size(96, 96);

            using (var inStream = new MemoryStream(bytes))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        imageFactory.Load(inStream)
                            .Format(new JpegFormat())
                            .Resize(imageSize)
                            .Quality(imageQuality)
                            .Save(outStream);
                    }

                    // rewind the memory stream so that it can be exported.
                    outStream.Position = 0;

                    return outStream.ToArray();
                }
            }
        }

        /// <summary>
        ///     Returns a 96 (w) x 96 (h) PNG image as byte[] of the Active Directory thumbnailPhoto for the specified username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Byte[] GetThumbnailPhotoAsPng(string userName)
        {
            byte[] bytes = GetThumbnailPhotoAsBitmap(userName);

            const int imageQuality = 95;
            var imageSize = new Size(96, 96);

            using (var inStream = new MemoryStream(bytes))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        imageFactory.Load(inStream)
                            .Format(new PngFormat())
                            .Resize(imageSize)
                            .Quality(imageQuality)
                            .Save(outStream);
                    }

                    // rewind the memory stream so that it can be exported.
                    outStream.Position = 0;

                    return outStream.ToArray();
                }
            }

        }
    }
}