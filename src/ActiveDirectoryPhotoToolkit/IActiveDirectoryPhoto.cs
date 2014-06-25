using System;
using System.Diagnostics.Contracts;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClass(typeof(IActiveDirectoryPhotoContracts))]
    public interface IActiveDirectoryPhoto
    {
        Byte[] GetThumbnailPhotoAsBitmap(string userName);
        Byte[] GetThumbnailPhotoAsJpeg(string userName);
    }
}
