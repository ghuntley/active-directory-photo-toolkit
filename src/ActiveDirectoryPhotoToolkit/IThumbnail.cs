namespace ActiveDirectoryPhotoToolkit
{
    internal interface IThumbnail
    {
        string Name { get; set; }
        byte[] ThumbnailData { get; set; }
        ActiveDirectoryPhoto.Format Format { get; set; }
    }
}