namespace INStudio.Data
{
    public class GalleryINMedia
    {
        public string GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public string INMediaId { get; set; }
        public INMedia INMedia { get; set; }
    }
}