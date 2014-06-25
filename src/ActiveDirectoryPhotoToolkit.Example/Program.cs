using System.DirectoryServices;
using System.IO;

namespace ActiveDirectoryPhotoToolkit.Example
{
    internal class Program
    {
        public static DirectoryEntry DirectoryEntry { get; private set; }
        public static IActiveDirectoryPhoto ActiveDirectoryPhoto { get; private set; }

        private static void Main(string[] args)
        {
            // 1. setup
            DirectoryEntry = new DirectoryEntry("LDAP://contoso.com");
            ActiveDirectoryPhoto = new ActiveDirectoryPhoto(DirectoryEntry);

            // 2. save thumbnailPhoto to disk.
            SaveThumbnailPhotoToDisk();
        }

        public static void SaveThumbnailPhotoToDisk()
        {
            const string username = "ghuntley";

            byte[] thumbnailPhoto = ActiveDirectoryPhoto.GetThumbnailPhotoAsJpeg(username);

            File.WriteAllBytes(username + ".jpg", thumbnailPhoto);
        }
    }
}