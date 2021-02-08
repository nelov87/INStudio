using System.Collections.Generic;
using INStudio.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace INStudio.Services
{
    public class GalleryService : IGalleryService
    {
        public ApplicationDbContext db { get; set; }
        public GalleryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddGallery(Gallery gallery)
        {
            bool operationOk = true;

            try
            {
                this.db.Gallerys.Add(gallery);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;

        }

        public bool DeleteGallery(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditGallery(Gallery gallery, string id)
        {
            bool operationOk = true;

            try{
                Gallery galeryToEdit = db.Gallerys.FirstOrDefault(x => x.Id == id);
                galeryToEdit.Title = gallery.Title;
                galeryToEdit.Description = gallery.Description;
                //galeryToEdit.GalleryINMedias


            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool GalleryExist(string id)
        {
            bool galleryExist = true;

            try{
                galleryExist = this.db.Gallerys.Any(x => x.Id == id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                galleryExist = false;
            }
            return galleryExist;
        }

        public ICollection<Gallery> GetAllGaleries()
        {
            HashSet<Gallery> galleries = new HashSet<Gallery>();

            try
            {
                galleries = this.db.Gallerys
                .Include(gi => gi.GalleryINMedias)
                .ToHashSet();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return galleries;
        }

        public Gallery GetGalery(string id)
        {
            Gallery gallery = new Gallery();

            try{
                gallery = this.db.Gallerys
                .Include(g => g.GalleryINMedias)
                .FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return gallery;
        }

    }
}