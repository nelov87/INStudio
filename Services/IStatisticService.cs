using System;
using System.Collections.Generic;
using INStudio.Data;





namespace INStudio.Services
{
    public interface IStatisticService
    {
         bool AddEntry(Statistic entry);
         ICollection<Statistic> GetAll();
         ICollection<Statistic> GetAllByPage(string pageId);
         ICollection<Statistic> GetAllByUser(string userId);
    }
}