using INStudio.Data;
using System.Collections.Generic;

namespace INStudio.Services
{
    public interface IINServicesService
    {
         bool AddINService(INServices service);
         bool EditINService(INServices newServices, string id);
         bool DeleteINService(string id);
         ICollection<INServices> GetAllINServices();
         INServices GetService(string id);
    }
}