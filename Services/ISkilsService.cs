using System.Collections.Generic;
using INStudio.Data;


namespace INStudio.Services
{
    public interface ISkilsService
    {
         bool AddSkill(Skils skill);
         bool EditSkill(Skils newSkill, string id);
         bool DeleteSkill(string id);
         Skils GetSkill(string id);
         ICollection<Skils> GetAllSkils();
    }
}