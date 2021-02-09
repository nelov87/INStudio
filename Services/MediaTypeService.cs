
using System;
using System.Collections.Generic;
using INStudio.Data;
using System.Linq;

namespace INStudio.Services
{
    public class MediaTypeService : IMediaTypeService
    {
        public ApplicationDbContext db { get; set; }

        public MediaTypeService(ApplicationDbContext bd)
        {
            this.db = db;
        }
        public bool AddMediaType(string type)
        {
            bool operationOk = true;
            MediaType mt = new MediaType();
            mt.Type = type;

            try{
                this.db.MediaTypes.Add(mt);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool DeleteMediaType(string typeToDelete)
        {
            bool operationOk = true;

            try
            {
                MediaType type = this.db.MediaTypes.FirstOrDefault(x => x.Type == typeToDelete);
                this.db.MediaTypes.Remove(type);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool EditMediaType(string olbType, string newType)
        {
            bool operationOk = true;

            try
            {
                this.db.MediaTypes.FirstOrDefault(m => m.Type == olbType).Type = newType;
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public ICollection<MediaType> GetAllMediaTypes()
        {
            HashSet<MediaType> mediaTypeList = new HashSet<MediaType>();

            try
            {
                mediaTypeList = this.db.MediaTypes.ToHashSet();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            return mediaTypeList;
        }
    }
}