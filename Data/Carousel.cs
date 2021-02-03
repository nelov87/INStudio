using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Carousel
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int? Number { get; set; }

        public bool Ative { get; set; }


        public Carousel()
        {
            this.Id = Guid.NewGuid().ToString();
                 
        }
    }
}
