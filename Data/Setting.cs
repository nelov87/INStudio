using System;
using System.ComponentModel.DataAnnotations;

namespace INStudio.Data
{
    public class Setting
    {
        [Key]
        public string Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }


        public Setting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Setting(string key, string value)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Key = key;
            this.Value = value;
        }
    }
}