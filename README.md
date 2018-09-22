![Icon](https://i.imgur.com/MJITwBP.png)
## Active Directory Photo Toolkit [![Build status](https://ci.appveyor.com/api/projects/status/k0v9fhu227g2cgel/branch/master?svg=true)](https://ci.appveyor.com/project/ghuntley/active-directory-photo-toolkit/branch/master)


## Installation

Installation is done via NuGet:

    Install-Package ActiveDirectoryPhotoToolkit

## Usage

Initial setup:

    var activeDirectoryPhoto = new ActiveDirectoryPhoto();

Retrieve a users profile photo from Active Directory

    var username = "ghuntley";
    var format = ActiveDirectoryPhoto.Format.PNG;
    var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);
    
Available formats are available in the ActiveDirectoryPhoto.Format enum.
     
     public enum Format
        {
            Bmp, 
            Gif, 
            Jpg, 
            Png
        };
    
Saving a retrieved user profile photo to disk in the same folder as the execution, after using the above sample
    
    activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto);

Saving a retrieved user to a specific folder, after using the retrieve a thumbnail example 

    activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto, "C:\\");

Setting a users profile photo
    
    var username = "ghuntley";
    var photo = @"C:\photo.jpg";
    activeDirectoryPhoto.SetThumbnailPhoto(username, photo);
    
Removing a users profile photo
    
    var username = "ghuntley";
    activeDirectoryPhoto.RemoveThumnnailPhoto(username);

## Custom Exceptions
There are two custom exceptions currently which can be caught and handled however you like.
> PhotoResolutionInvalidException - Thrown when the image selected to upload is larger than 200x200px which is the limit set in Active Directory.
> PhotoTooLargeException - Thrown when the image selected is larger than 100kb, again this is a limit set in Acitve Directory.

## With thanks to
* The icon "<a href="http://thenounproject.com/term/man/32098/" target="_blank">Man</a>" designed by <a href="http://thenounproject.com/SimpleIcons" target="_blank">Simple Icons</a> from The Noun Project.
* [ghuntley](https://github.com/ghuntley/) for the initial work
* [CaptainQwerty](https://github.com/captainqwerty/) for aditional feature implmenation

