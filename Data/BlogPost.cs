using System;
using System.Collections.Generic;
using Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class BlogPost
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public INMedia PostImage { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }

        public bool Active { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }
        public string AppUserId { get; set; }
        public AppUser Author { get; set; }
        public string GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool ComentsIsActive { get; set; }

        public BlogPost()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DateCreated = DateTime.Now;
            this.PostCategories = new HashSet<PostCategory>();
            this.Active = true;
            this.Comments = new HashSet<Comment>();
            this.ComentsIsActive = true;
        }
    }
}