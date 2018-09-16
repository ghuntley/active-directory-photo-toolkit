![Icon](https://i.imgur.com/MJITwBP.png)
## Active Directory Photo Toolkit [![Build status](https://ci.appveyor.com/api/projects/status/k0v9fhu227g2cgel/branch/master?svg=true)](https://ci.appveyor.com/project/ghuntley/active-directory-photo-toolkit/branch/master)


## Installation

Installation is done via NuGet:

    Install-Package ActiveDirectoryPhotoToolkit

## Usage

Initial setup:

    var activeDirectoryPhoto = new ActiveDirectoryPhoto();

Retrieve a users profile photo from Active Directory

    var username = "ghuntley"
    var format = ActiveDirectoryPhoto.Format.PNG;
    var thumbnailPhoto = activeDirectoryPhoto.GetThumbnailPhoto(username, format);
    
Available formats are available in the ActiveDirectoryPhoto.Format enum.
     
     public enum Format
        {
            BMP, GIF, JPG, PNG
        }
    
Saving a retrieved user profile photo to disk in the same folder as the execution, after using the above sample
    
    activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto);

Saving a retrieved user to a specific folder, after using the retrieve a thumbnail example 

    activeDirectoryPhoto.SaveThumbnailToDisk(thumbnailPhoto, "C:\\");
  
Setting a users profile photo
    
    var username = "ghuntley"
    var photo = @"C:\photo.jpg"
    activeDirectoryPhoto.SetThumbnailPhoto(username, photo);

## With thanks to
* The icon "<a href="http://thenounproject.com/term/man/32098/" target="_blank">Man</a>" designed by <a href="http://thenounproject.com/SimpleIcons" target="_blank">Simple Icons</a> from The Noun Project.
