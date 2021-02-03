using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace INStudio.Data
{
    public class Services
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageId { get; set; }

        public INMedia Image { get; set; }
        
        public string Link { get; set; }

        public Services()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Image = new INMedia();
        }

    }
}
