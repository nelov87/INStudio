using INStudio.Data;
using System.Collections.Generic;

namespace INStudio.Services
{
    public interface IPostService
    {
         bool AddPost(BlogPost postToAdd);
         bool EditPost(BlogPost postToEdit, string postId);
         bool DeletPost(string id);
         BlogPost GetPost(string id);
         ICollection<BlogPost> GetAllPosts();
         ICollection<BlogPost> GetPostsByCategory(string categoryId);
         bool PostExist(string id);
    }
}