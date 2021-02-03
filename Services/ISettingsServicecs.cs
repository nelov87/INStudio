using System.Collections.Generic;

namespace INStudio.Services
{
    public interface ISettingsServicecs
    {
        string GetSetting(string key);
        Dictionary<string,string> GetAllSettings();
        bool AddSetting(string key, string value);
        bool EditSetting(string key, string newValue);
        bool DeleteSetting(string key, string value);
    }
}