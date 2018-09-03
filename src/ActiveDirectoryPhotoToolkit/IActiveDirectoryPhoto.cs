using System;
using System.Diagnostics.Contracts;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClass(typeof(ActiveDirectoryPhotoContracts))]
    public interface IActiveDirectoryPhoto
    {
        byte[] GetThumbnailPhoto(string userName, string format);
        void SetThumbnailPhoto(string userName, string thumbNailLocation);
    }
}
