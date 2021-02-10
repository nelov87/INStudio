using System.Collections.Generic;
using INStudio.Data;

namespace INStudio.Services
{
    public interface ILogService
    {
         void AddLog(string message, string logType);
         ICollection<Log> GetAllLogs();
         ICollection<Log> GetAllByType(string type);
    }
}