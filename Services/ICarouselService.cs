using System.Collections.Generic;
using INStudio.Data;


namespace INStudio.Services
{
    public interface ICarouselService
    {
         bool AddCarousel(Carousel carousel);
         bool EditCarousel(Carousel newCarousel, string id);
         bool DeleteCarousel(string id);
         ICollection<Carousel> GetAllCarouse();
         Carousel GetCarousel(string id);

    }
}