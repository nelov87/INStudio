using System.Collections.Generic;
using INStudio.Data;
using System;
using System.Linq;

namespace INStudio.Services
{
    public class PostService : IPostService
    {
        public ApplicationDbContext db { get; set; }

        public PostService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddPost(BlogPost postToAdd)
        {
            bool operationOk = true;

            try
            {
                this.db.BlogPosts.Add(postToAdd);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }
            return operationOk;
        }

        public bool DeletPost(string id)
        {
            bool operationOk = true;

            try
            {
                BlogPost bpToDelete = this.db.BlogPosts.FirstOrDefault(x => x.Id == id);
                PostCategory[] pcToDelete = this.db.PostCategories.Where(x => x.BlogPostId == id).ToArray();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }
            return operationOk;
        }

        public bool EditPost(BlogPost postCorrected, string id)
        {
            bool operationOk = true;

            try{
                BlogPost bpToEdit = this.db.BlogPosts.FirstOrDefault(x => x.Id == id);
                bpToEdit.Title = postCorrected.Title;
                bpToEdit.Content = postCorrected.Content;
                bpToEdit.GalleryId = postCorrected.GalleryId;
                bpToEdit.PostImage = postCorrected.PostImage;
                bpToEdit.DateEdited = DateTime.Now;
                
            }catch(Exception e){
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public ICollection<BlogPost> GetAllPosts()
        {
            HashSet<BlogPost> listToReturn = new HashSet<BlogPost>();

            try{
                listToReturn = this.db.BlogPosts.ToHashSet();
            }
            catch(Exception e)
            {
                Console.WriteLine();
            }
            return listToReturn;
        }

        public BlogPost GetPost(string id)
        {
            BlogPost bpToReturn = new BlogPost();

            try{
                bpToReturn = this.db.BlogPosts.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return bpToReturn;
        }

        public ICollection<BlogPost> GetPostsByCategory(string categoryId)
        {
                PostCategory[] postCategories = 
                this.db.PostCategories
                .Where(x => x.CategoryId == categoryId)
                .ToArray();

                HashSet<BlogPost> blogPosts = new HashSet<BlogPost>();
                foreach(var pc in postCategories)
                {
                    blogPosts.Add(this.db.BlogPosts.FirstOrDefault(x => x.Id == pc.BlogPostId));
                }
            return blogPosts;
        }

        public bool PostExist(string id)
        {
            if(this.db.BlogPosts.Any(x => x.Id == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}