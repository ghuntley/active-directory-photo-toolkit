using System;
using System.Diagnostics.Contracts;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClassFor(typeof(IActiveDirectoryPhoto))]
    internal abstract class ActiveDirectoryPhotoContracts : IActiveDirectoryPhoto
    {
        public byte[] GetThumbnailPhoto(string userName, string format)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(userName));

            throw new NotImplementedException();
        }
    }
}
