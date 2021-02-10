using System.Collections.Generic;
using INStudio.Data;

namespace INStudio.Services
{
    public interface ICommentService
    {
        bool AddComment(Comment comment);
        bool EditComment(string comment, string id);
        bool DeleteComment(string id);

        ICollection<Comment> GetAllComments();

        Comment GetComment(string id);
        ICollection<Comment> GetAllForPost(string postId);
    }
}