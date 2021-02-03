using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class MediaType
    {
        [Key]
        public string Id { get; set; }
        public string Type { get; set; }
        public ICollection<INMedia> INMedias { get; set; }

        public MediaType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.INMedias = new HashSet<INMedia>();
        }
        
    }
}