namespace ActiveDirectoryPhotoToolkit
{
    public class Thumbnail : IThumbnail
    {
        public string Name { get; set; }
        public byte[] ThumbnailData { get; set; }
        public ActiveDirectoryPhoto.Format Format { get; set; }        
    }
}
