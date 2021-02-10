using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.Data;
using INStudio.GlobalConstants;

namespace INStudio.Services
{
    public class CommentService : ICommentService
    {
        public ApplicationDbContext db { get; set; }

        public CommentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddComment(Comment comment)
        {
            bool operationOk = true;

            try{
                this.db.Comments.Add(comment);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
                operationOk = false;
            }
            return operationOk;
        }

        public bool DeleteComment(string id)
        {
            bool operationOk = true;

            try{
                Comment comment = this.db.Comments.FirstOrDefault(x => x.Id == id);
                this.db.Comments.Remove(comment);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
                operationOk = false;
            }
            return operationOk;
        }

        public bool EditComment(string comment, string id)
        {
            bool operationOk = true;

            try{
                Comment oldComment = this.db.Comments.FirstOrDefault(x => x.Id == id);
                oldComment.CommentText = comment;
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
                operationOk = false;
            }
            return operationOk;
        }

        public ICollection<Comment> GetAllComments()
        {
            HashSet<Comment> commentsList = new HashSet<Comment>();

            try{
                commentsList = this.db.Comments.ToHashSet();

            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
            }
            return commentsList;

        }

        public Comment GetComment(string id)
        {
            Comment comment = new Comment();

            try{
                comment = this.db.Comments.FirstOrDefault(x => x.Id == id);

            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
            }
            return comment;
        }

        public ICollection<Comment> GetAllForPost(string postId)
        {
            HashSet<Comment> postComments = new HashSet<Comment>();

            try{
                postComments = this.db.Comments
                .Where(x => x.BlogPostId == postId)
                .ToHashSet();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
            }
            return postComments;
        }
    }
}