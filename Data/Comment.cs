using System;
using Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string CommentText { get; set; }
        public string BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public bool Visable { get; set; }
        public string AppUserId { get; set; }
        public AppUser Author { get; set; }


        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BlogPost = new BlogPost();

        }
    }
}