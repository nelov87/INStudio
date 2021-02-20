using System;
using System.ComponentModel.DataAnnotations;
using INStudio.GlobalConstants;

namespace INStudio.Data
{
    public class Log
    {
        [Key]
        public string Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Log()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Message = "";
            this.Type = LogTypes.Non.ToString();
            this.Date = DateTime.Now;
        }
        public Log(string massage, string type)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Message = massage;
            this.Type = type;
            this.Date = DateTime.Now;
        }
    }
}