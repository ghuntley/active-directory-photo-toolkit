using System;
using System.IO;

namespace ActiveDirectoryPhotoToolkit.Example
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            // 1. Setup
            var activeDirectoryPhoto = new ActiveDirectoryPhoto();

            Console.Write("Username: ");
            var username = Console.ReadLine();

            // 2. Setting a Thumbnail
            activeDirectoryPhoto.SetThumbnailPhoto(username, @"C:\photo.jpg");

            // 3. Getting a Thumbnail
            var format = ActiveDirectoryPhoto.Format.PNG;
            var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);

            // 4. Save the file to disk
            //activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto, "C:\\");
            File.WriteAllBytes(username + "." + format, thumbnailPhoto);
        }
    }
}