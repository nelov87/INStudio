using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.Data;
using INStudio.GlobalConstants;

namespace INStudio.Services
{
    public class CarouselService : ICarouselService
    {
        public ApplicationDbContext db { get; set; }

        public CarouselService(ApplicationDbContext dbb)
        {
            this.db = dbb;
        }
        public bool AddCarousel(Carousel carousel)
        {
            bool operationOk = true;
            
            try{
                this.db.Carousels.Add(carousel);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                operationOk = false;
                this.db.SaveChanges();
            }

            return operationOk;
        }

        public bool DeleteCarousel(string id)
        {
            bool operationOk = true;

            try{
                Carousel carousel = this.db.Carousels.FirstOrDefault(c => c.Id == id);
                this.db.Carousels.Remove(carousel);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
                operationOk = false;
            }
            return operationOk;
        }

        public bool EditCarousel(Carousel newCarousel, string id)
        {
            bool operationOk = true;

            try{
                Carousel oldCarousel = this.db.Carousels.FirstOrDefault(c => c.Id == id);
                oldCarousel.Title = newCarousel.Title;
                oldCarousel.Description = newCarousel.Description;
                oldCarousel.Ative = newCarousel.Ative;
                oldCarousel.Link = newCarousel.Link;
                oldCarousel.Number = newCarousel.Number;
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
                operationOk = false;
            }
            return operationOk;
        }

        public ICollection<Carousel> GetAllCarouse()
        {
            HashSet<Carousel> carouselList = new HashSet<Carousel>();

            try{
                carouselList = this.db.Carousels.ToHashSet();
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
            }

            return carouselList;
        }

        public Carousel GetCarousel(string id)
        {
            Carousel carousel = new Carousel();

            try{
                carousel = this.db.Carousels.FirstOrDefault(c => c.Id == id);
            }
            catch(Exception e)
            {
                this.db.Logs.Add(new Log(e.Message, LogTypes.Error.ToString()));
                this.db.SaveChanges();
            }
            return carousel;
        }
    }
}