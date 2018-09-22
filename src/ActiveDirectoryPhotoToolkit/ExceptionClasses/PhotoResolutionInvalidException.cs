using System;

namespace ActiveDirectoryPhotoToolkit.ExceptionClasses
{
    internal class PhotoResolutionInvalidException : Exception
    {
        public PhotoResolutionInvalidException()
            : base("The resolution of the photo is invalid or exceeds the maximum 200x200px.")
        {
        }
    }
}
