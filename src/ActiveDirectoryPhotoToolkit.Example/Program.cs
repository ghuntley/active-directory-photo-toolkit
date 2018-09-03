using System;
using System.IO;

namespace ActiveDirectoryPhotoToolkit.Example
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            var activeDirectoryPhoto = new ActiveDirectoryPhoto();

            Console.Write("Username: ");
            var username = Console.ReadLine();

            var format = ActiveDirectoryPhoto.Format.Bitmap;

            activeDirectoryPhoto.SetThumbnailPhoto(username, @"C:\face2.jpg");

            var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);

            File.WriteAllBytes(username + format, thumbnailPhoto);
        }
    }
}