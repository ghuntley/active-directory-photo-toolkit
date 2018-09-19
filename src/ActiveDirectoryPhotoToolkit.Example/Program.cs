using System;

namespace ActiveDirectoryPhotoToolkit.Example
{
    internal class Program
    {
        private static void Main()
        {
            // 1. Setup
            var activeDirectoryPhoto = new ActiveDirectoryPhoto();

            // Example for getting the username
            Console.Write("Username: ");
            var username = Console.ReadLine();

            // 2. Setting a Thumbnail
            var photoLocation = @"C:\photo.jpg";
            activeDirectoryPhoto.SetThumbnailPhoto(username, photoLocation);

            // 3. Getting a Thumbnail
            var format = ActiveDirectoryPhoto.Format.Gif;
            var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);

            // 4. Save the file to disk where the program is launched from
            activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto);

            // 5. Save the file to disk at a particular location
            var saveLocation = @"C:\";
            activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto, saveLocation);

            // 6. Remove a users thumbnail photo
            activeDirectoryPhoto.RemoveThumnnailPhoto(username);
        }
    }
}