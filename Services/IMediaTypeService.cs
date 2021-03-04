using System;
using System.Linq;
using System.Collections.Generic;
using INStudio.Data;


namespace INStudio.Services
{
    public interface IMediaTypeService
    {
         bool AddMediaType(string type);
         bool EditMediaType(string olbType, string newType);
         bool DeleteMediaType(string id);
         ICollection<MediaType> GetAllMediaTypes();
         
    }
}