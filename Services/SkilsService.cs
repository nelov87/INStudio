using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.GlobalConstants;
using INStudio.Data;

namespace INStudio.Services
{
    public class SkilsServiceb : ISkilsService
    {
        public ApplicationDbContext db { get; set; }
        public ILogService logService { get; set; }

        public SkilsService(ApplicationDbContext db, ILogService ls)
        {
            this.db = db;
            this.logService = ls;
        }
        public bool AddSkill(Skils skill)
        {
            bool operationOk = true;

            try
            {
                this.db.Skils.Add(skill);
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
            }
        }

        public bool DeleteSkill(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditSkill(Skils newSkill, string id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Skils> GetAllSkils()
        {
            throw new System.NotImplementedException();
        }

        public Skils GetSkill(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}