using System;
using System.Collections.Generic;
using System.Linq;
using INStudio.Data;


namespace INStudio.Services
{
    public class INServicesService : IINServicesService
    {
        public ApplicationDbContext db { get; set; }

        public INServicesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddINService(INServices service)
        {
            bool operationOk = true;

            try{
                this.db.INServices.Add(service);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool DeleteINService(string id)
        {
            bool operationOk = true;

            try{
                INServices ins = this.db.INServices.FirstOrDefault(s => s.Id == id);
                this.db.INServices.Remove(ins);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool EditINService(INServices newServices, string id)
        {
            bool operationOk = true;

            try{
                INServices oldService = this.db.INServices.FirstOrDefault(x => x.Id == id);
                oldService.Title = newServices.Title;
                oldService.Description = newServices.Description;
                oldService.Link = newServices.Link;
                oldService.Image = newServices.Image;
                oldService.ImageId = newServices.ImageId;

                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }
            return operationOk;
        }

        public ICollection<INServices> GetAllINServices()
        {
            HashSet<INServices> iNServicesList = new HashSet<INServices>();

            try{
                iNServicesList = this.db.INServices.ToHashSet();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return iNServicesList;
        }

        public INServices GetService(string id)
        {
            INServices service = new INServices();

            try{
                service = this.db.INServices.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return service;
        }
    }
}