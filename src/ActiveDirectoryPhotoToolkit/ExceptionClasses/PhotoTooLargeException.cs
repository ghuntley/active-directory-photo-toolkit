using System;

namespace ActiveDirectoryPhotoToolkit.ExceptionClasses
{
    internal class PhotoTooLargeException : Exception
    {
        public PhotoTooLargeException()
            : base("The size of the image exceeds the maximum 100kb size allowed by Active Directory.")
        {
        }
    }
}
