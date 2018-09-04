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

            var format = ActiveDirectoryPhoto.Format.PNG;


            // 2. Setting a Thumbnail
            //activeDirectoryPhoto.SetThumbnailPhoto(username, @"C:\face2.jpg");


            // 3. Getting a Thumbnail
            var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);


            // 4. Save the file
            File.WriteAllBytes(username + "." + format, thumbnailPhoto);
        }
    }
}