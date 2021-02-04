using System.Collections.Generic;
using System;
using INStudio.Data;


namespace INStudio.Services
{
    public interface IINMediaService
    {
        ICollection<INMedia> GetImages();


        bool AddImage(INMedia media);

        bool EditImage(string id, INMedia media);

        bool DeleteImage(string id);

        INMedia GetImage(string id);

        ICollection<INMedia> GetImagesByGaleryImage(string galleryId);
    }
}