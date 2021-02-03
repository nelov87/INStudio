using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
        public ICollection<INMediaCategory> INMediCategories { get; set; }

        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PostCategories = new HashSet<PostCategory>();
            this.INMediCategories = new HashSet<INMediaCategory>();
        }
    }
}