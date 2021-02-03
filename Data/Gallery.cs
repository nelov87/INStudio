using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Gallery
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<GalleryINMedia> GalleryINMedias{ get; set; }

        public Gallery()
        {
            this.Id = Guid.NewGuid().ToString();
            this.GalleryINMedias = new HashSet<GalleryINMedia>();
        }
    }
}
