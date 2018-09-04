using System;
using System.Diagnostics.Contracts;

namespace ActiveDirectoryPhotoToolkit
{
    [ContractClass(typeof(ActiveDirectoryPhotoContracts))]
    public interface IActiveDirectoryPhoto
    {
        Thumbnail GetThumbnailPhoto(string userName, ActiveDirectoryPhoto.Format format);
        void SetThumbnailPhoto(string userName, string thumbNailLocation);
        void SaveThumbnailToDisk(Thumbnail thumbnail);
        void SaveThumbnailToDisk(Thumbnail thumbnail, string location);
    }
}
