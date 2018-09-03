using System.IO;

namespace ActiveDirectoryPhotoToolkit.Example
{
    internal class Program
    {
        public static IActiveDirectoryPhoto ActiveDirectoryPhoto { get; private set; }

        private static void Main(string[] args)
        {
            // 1. setup
            ActiveDirectoryPhoto = new ActiveDirectoryPhoto();

            // 2. save thumbnailPhoto to disk.
            SaveThumbnailPhotoToDisk();
        }

        public static void SaveThumbnailPhotoToDisk()
        {
            const string username = "ghuntley";

            var thumbnailPhoto = ActiveDirectoryPhoto.GetThumbnailPhoto(username, "JPG");
            File.WriteAllBytes(username + ".jpg", thumbnailPhoto);
        }
    }
}