using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveDirectoryPhotoToolkit.ExceptionClasses
{
    internal class PhotoResolutionInvalidException : Exception
    {
        public PhotoResolutionInvalidException()
            : base("The resolution of the photo is invalid.")
        {
        }
    }
}
