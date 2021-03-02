using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.GlobalConstants;
using INStudio.Data;

namespace INStudio.Services
{
    public class SkilsService : ISkilsService
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
                operationOk = false;
            }

            return operationOk;
        }

        public bool DeleteSkill(string id)
        {
            bool operationOk = true;

            try
            {
                Skils skil = this.db.Skils.FirstOrDefault(x => x.Id == id);
                this.db.Skils.Remove(skil);
                this.db.SaveChanges();
            }
            catch (System.Exception e)
            {
                
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
                operationOk = false;
            }
            return operationOk;
        }

        public bool EditSkill(Skils newSkill, string id)
        {
            bool operationOk = true;

            try
            {
                Skils oldSkil = this.db.Skils.FirstOrDefault(x => x.Id == id);
                oldSkil.Content = newSkill.Content;
                oldSkil.Image = newSkill.Image;
                oldSkil.ImageId = newSkill.ImageId;
                oldSkil.Title = newSkill.Title;
            }
            catch (System.Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
                operationOk = false;
            }
            return operationOk;
        }

        public ICollection<Skils> GetAllSkils()
        {
            HashSet<Skils> sklisList = new HashSet<Skils>();

            try
            {
                sklisList = this.db.Skils.ToHashSet();
            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
            }
            return sklisList;
        }

        public Skils GetSkill(string id)
        {
            Skils skil = new Skils();

            try
            {
                skil = this.db.Skils.FirstOrDefault(x => x.Id == id);

            }
            catch(Exception e)
            {
                this.logService.AddLog(e.Message, LogTypes.Error.ToString());
            }
            return skil;
        }

        public string GetImagePath(string id)
        {
            return this.db.INMedias.FirstOrDefault(x => x.Id == id).Path;
        }
    }
}