using System;
using System.Collections.Generic;
using System.Linq;
using INStudio.Data;


namespace INStudio.Services
{
    public interface IGalleryService
    {
         bool AddGallery(Gallery gallery);
         bool EditGallery(Gallery gallery, string id);
         bool DeleteGallery(string id);

         Gallery GetGalery(string id);
         ICollection<Gallery> GetAllGaleries();
         
         bool GalleryExist(string id);



    }
}