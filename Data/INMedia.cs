using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class INMedia
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public string TypeId { get; set; }

        public MediaType Type { get; set; }

        public ICollection<INMediaCategory> INMediaCategories { get; set; }

        public ICollection<GalleryINMedia> GalleryINMedias { get; set; }

        public INMedia()
        {
            this.Id = Guid.NewGuid().ToString();
            this.INMediaCategories = new HashSet<INMediaCategory>();
            
            this.GalleryINMedias = new HashSet<GalleryINMedia>();
        }
    }
}
