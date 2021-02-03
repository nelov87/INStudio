namespace INStudio.Data
{
    public class INMediaCategory
    {
        public string INMediaId { get; set; }
        public INMedia INMedia { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}