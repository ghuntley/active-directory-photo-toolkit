using System;
using System.Diagnostics.Contracts;
using ActiveDirectoryPhotoToolkit;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClassFor(typeof(IActiveDirectoryPhoto))]
    internal abstract class ActiveDirectoryPhotoContracts : IActiveDirectoryPhoto
    {
        public byte[] GetThumbnailPhoto(string userName, ActiveDirectoryPhoto.Format format)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }

        public void SetThumbnailPhoto(string userName, string thumbNailLocation)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }
    }
}
