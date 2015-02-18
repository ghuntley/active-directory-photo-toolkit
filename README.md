![Icon](https://i.imgur.com/MJITwBP.png)
## Active Directory Photo Toolkit [![Build status](https://ci.appveyor.com/api/projects/status/k0v9fhu227g2cgel/branch/master?svg=true)](https://ci.appveyor.com/project/ghuntley/active-directory-photo-toolkit/branch/master)


## Installation

Installation is done via NuGet:

    Install-Package ActiveDirectoryPhotoToolkit

## Usage

Initial setup:

    var directoryEntry = new DirectoryEntry("LDAP://contoso.com");
    var adPhoto = new ActiveDirectoryPhoto(directoryEntry);

Retreive a users profile photo from Active Directory in the native format - Bitmap:

    var bitmap = adPhoto.GetThumbnailPhotoAsBitmap("ghuntley");

Retreive a users profile photo from Active Directory and convert from native format (Bitmap) to a Jpeg:

    var jpeg = adPhoto.GetThumbnailPhotoAsJpeg("ghuntley");

Retreive a users profile photo from Active Directory and convert from native format (Bitmap) to a Png:

    var png = adPhoto.GetThumbnailPhotoAsPng("ghuntley");

## Remarks

The ability to set a users profile photo is within scope but at this stage is not implemented. This will be revisted in the future but please consider forking this libary, implementing it yourself and submitting a pull-request.

## With thanks to
* The icon "<a href="http://thenounproject.com/term/man/32098/" target="_blank">Man</a>" designed by <a href="http://thenounproject.com/SimpleIcons" target="_blank">Simple Icons</a> from The Noun Project.
