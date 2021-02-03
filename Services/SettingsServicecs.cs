using System.Collections.Generic;
using INStudio.Data;
using System;
using System.Linq;

namespace INStudio.Services
{
    public class SettingsServicecs : ISettingsServicecs
    {
        public ApplicationDbContext db { get; set; }

        public SettingsServicecs(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddSetting(string key, string value)
        {
            Setting newSetting = new Setting(key, value);
            bool operationOk = true; 
            
            try
            {
                this.db.Settings.Add(newSetting);
                this.db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
            
        }

        public bool DeleteSetting(string key, string value)
        {
            bool operationOk = true;

            try
            {
                this.db.Settings.Remove(this.db.Settings.FirstOrDefault(x => x.Key == key));

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public bool EditSetting(string key, string newValue)
        {
            bool operationOk = true;

            try
            {
                Setting setting = this.db.Settings.FirstOrDefault(x => x.Key == key);
                setting.Value = newValue;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                operationOk = false;
            }

            return operationOk;
        }

        public Dictionary<string, string> GetAllSettings()
        {
            
            Dictionary<string, string> settingsList = new Dictionary<string, string>();
            
            try
            {
                var settingsFromDb = this.db.Settings.ToHashSet();

                foreach(Setting setting in settingsFromDb)
                {
                    settingsList.Add(setting.Key, setting.Value);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            return settingsList;
        }

        public string GetSetting(string key)
        {
            string setting = "";

            try
            {
                setting = this.db.Settings.FirstOrDefault(x => x.Key == key).Value;
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            return setting;
        }
    }
}