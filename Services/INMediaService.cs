using System.Collections.Generic;
using INStudio.Data;
using System;
using System.Linq;


namespace INStudio.Services
{
    public class INMediaService : IINMediaService
    {
        public ApplicationDbContext db { get; set; }
        public INMediaService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddImage(INMedia media)
        {
            bool operationOk = true;

            try
            {
                this.db.INMedias.Add(media);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool DeleteImage(string id)
        {
            bool operationOk = true;

            try
            {
                GalleryINMedia[] gi = this.db.GalleryINMedias.Where(x => x.INMediaId == id).ToArray();
                this.db.GalleryINMedias.RemoveRange(gi);
                INMedia mediaToRemove = this.db.INMedias.FirstOrDefault(x => x.Id == id);
                this.db.INMedias.Remove(mediaToRemove);
                this.db.SaveChanges();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool EditImage(string id, INMedia media)
        {
            bool operationOk = false;

            try
            {
                INMedia mediaToEdit = this.db.INMedias.FirstOrDefault(x => x.Id == id);
                mediaToEdit.Title = media.Title;
                mediaToEdit.Description = media.Description;
                mediaToEdit.Path = media.Path;
                mediaToEdit.Type = media.Type;
                mediaToEdit.TypeId = media.TypeId;
                
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public INMedia GetImage(string id)
        {
            INMedia mediaToReturn;
            try
            {
                mediaToReturn = this.db.INMedias.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                mediaToReturn = new INMedia(){Title = "Default Media", Path = "/images/defoultimage.png"};
            }
            return mediaToReturn;
        }

        public ICollection<INMedia> GetImages()
        {
            HashSet<INMedia> imageList = new HashSet<INMedia>();

            try
            {
                imageList = this.db.INMedias.ToHashSet();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                imageList.Add(new INMedia(){Title = "Default Media. NoImages", Path = "/images/defoultimage.png"});
            }
            return imageList;
        }

        public ICollection<INMedia> GetImagesByGaleryImage(string galleryId)
        {
            HashSet<INMedia> imageList = new HashSet<INMedia>();

            try{
                GalleryINMedia[] gm = this.db.GalleryINMedias.Where(x => x.GalleryId == galleryId).ToArray();
                
                foreach(var galleryPair in gm)
                {
                    imageList.Add(this.db.INMedias.FirstOrDefault(x => x.Id == galleryPair.INMediaId));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return imageList;
        }
    }
}