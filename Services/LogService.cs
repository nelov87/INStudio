using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.Data;
using INStudio.GlobalConstants;

namespace INStudio.Services
{
    public class LogService : ILogService
    {
        public ApplicationDbContext db { get; set; }

        public LogService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddLog(string message, string logType)
        {
            this.db.Logs.Add(new Log(message, logType));
            this.db.SaveChanges();
        }

        public ICollection<Log> GetAllByType(string type)
        {
            HashSet<Log> logsList = new HashSet<Log>();

            try{
                logsList = this.db.Logs.Where(x => x.Type == type).ToHashSet();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
            }

            return logsList;
        }

        public ICollection<Log> GetAllLogs()
        {
            HashSet<Log> logsList = new HashSet<Log>();

            try{
                logsList = this.db.Logs.ToHashSet();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
            }

            return logsList;
        }
    }
}