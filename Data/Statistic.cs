using System;


namespace INStudio.Data
{
    public class Statistic
    {
        public string Id { get; set; }
        public string PageId { get; set; }
        public DateTime Time { get; set; }
        #nullable enable
        public string? UserId { get; set; }

        public Statistic()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Time = DateTime.Now;
        }

        public Statistic(string pageId, string? userId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Time = DateTime.Now;
            this.PageId = pageId;
            this.UserId = userId;
        }
    }
}