namespace INStudio.Data
{
    public class PostCategory
    {
        public string BlogPostId { get; set; }
        public BlogPost Post { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public PostCategory()
        {
            
        }

        public PostCategory(string blogPostId, string categoryId)
        {
            this.BlogPostId = blogPostId;
            this.CategoryId = categoryId;
            
        }
    }
}