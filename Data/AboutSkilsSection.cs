using System;
using System.ComponentModel.DataAnnotations;
namespace INStudio.Data
{
    public class AboutSkilsSection
    {
        [Key]
        public string Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public INMedia Image { get; set; }
        public INMedia Video { get; set; }
        public AboutSkilsSection()
        {
            this.Id = Guid.NewGuid().ToString();
            
        }
    }
}