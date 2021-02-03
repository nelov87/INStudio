using System;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Skils
    {
        [Key]
        public string Id { get; set; } 
        public string Title { get; set; }   
        public string Content { get; set; }
        public string ImageId { get; set; }
        public INMedia Image { get; set; }


        public Skils()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Image = new INMedia();
        }
    }
}