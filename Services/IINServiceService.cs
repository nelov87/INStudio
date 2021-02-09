using INStudio.Data;
using System.Collections.Generic;

namespace INStudio.Services
{
    public interface IINServiceService
    {
         bool AddINService(INServices service);
         bool EditINService(INServices newServices, string id);
         bool DeleteINService(string id);
         ICollection<INServices> GetAllINServices();
         INServices GetService(string id);
    }
}