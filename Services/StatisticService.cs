using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.Data;
using INStudio.GlobalConstants;

namespace INStudio.Services
{
    public class StatisticService : IStatisticService
    {
        public ApplicationDbContext db { get; set; }
        public ILogService logService { get; set; }

        public StatisticService(ApplicationDbContext db, ILogService logService)
        {
            this.db = db;
            this.logService = logService;
        }

        public bool AddEntry(Statistic entry)
        {
            bool opperationOk = true;

            try{
                this.db.Statistics.Add(entry);
            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
                opperationOk = false;
            }
            return opperationOk;
        }

        public ICollection<Statistic> GetAll()
        {
            HashSet<Statistic> statisticsList = new HashSet<Statistic>();

            try{
                statisticsList = this.db.Statistics.ToHashSet();
            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());

            }
            return statisticsList;
        }

        public ICollection<Statistic> GetAllByPage(string pageId)
        {
            HashSet<Statistic> statisticsList = new HashSet<Statistic>();

            try{
                statisticsList = this.db.Statistics
                .Where(x => x.PageId == pageId)
                .ToHashSet();
            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());

            }
            return statisticsList;
        }

        public ICollection<Statistic> GetAllByUser(string userId)
        {
            HashSet<Statistic> statisticsList = new HashSet<Statistic>();

            try{
                statisticsList = this.db.Statistics
                .Where(x => x.UserId == userId)
                .ToHashSet();
            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());

            }
            return statisticsList;
        }
    }
}