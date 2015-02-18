using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClassFor(typeof(IActiveDirectoryPhoto))]
    abstract class IActiveDirectoryPhotoContracts : IActiveDirectoryPhoto
    {
        public byte[] GetThumbnailPhotoAsBitmap(string userName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }

        public byte[] GetThumbnailPhotoAsJpeg(string userName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }

        public byte[] GetThumbnailPhotoAsPng(string userName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }
    }
}
