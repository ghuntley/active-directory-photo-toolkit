using System;
using System.Diagnostics.Contracts;

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

        public void SaveThumbnailToDisk(byte[] thumbNail, string location)
        {
            throw new NotImplementedException();
        }

        public void SaveThumbnailToDisk(byte[] thumbNail)
        {
            throw new NotImplementedException();
        }

        public void SetThumbnailPhoto(string userName, string thumbNailLocation)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }
    }
}
