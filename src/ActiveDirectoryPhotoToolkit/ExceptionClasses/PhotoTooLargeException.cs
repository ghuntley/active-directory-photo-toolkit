using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveDirectoryPhotoToolkit.ExceptionClasses
{
    class PhotoTooLargeException : Exception
    {
        public PhotoTooLargeException()
            : base("The size of the image exceeds the maximum size allowed by Active Directory.")
        {
        }
    }
}
