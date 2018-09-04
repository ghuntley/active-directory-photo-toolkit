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

        public void SetThumbnailPhoto(string userName, string thumbNailLocation)
        {
            throw new NotImplementedException();
        }


        Thumbnail IActiveDirectoryPhoto.GetThumbnailPhoto(string userName, ActiveDirectoryPhoto.Format format)
        {
            throw new NotImplementedException();
        }


        public void SaveThumbnailToDisk(Thumbnail thumbnail)
        {
            throw new NotImplementedException();
        }

        public void SaveThumbnailToDisk(Thumbnail thumbnail, string location)
        {
            throw new NotImplementedException();
        }
    }
}
