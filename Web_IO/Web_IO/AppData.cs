using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_IO
{
    internal class AppData
    {
        #region properties
        public string App { get; set; }
        public string Category { get; set; }
        public string Rating { get; set; }
        public string Reviews { get; set; }
        public string Size { get; set; }
        public string Installs { get; set; }
        public Enums.Type Type { get; set; }
        public string Price { get; set; }
        public string ContentRating { get; set; }
        public string Genres { get; set; } 
        public string LastUpdated { get; set; }
        public string CurrentVersion { get; set; }
        public string AndroidVersion { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
        public string ToCsvString(char sep, AppData appData)
        {
            return appData.App + sep + appData.Category + sep + appData.Rating + sep + appData.Reviews +
                   sep + appData.Size + sep + appData.Installs + sep + appData.Type + sep + appData.Price +
                   sep + appData.ContentRating + sep + appData.Genres +
                   sep + appData.LastUpdated + sep + appData.CurrentVersion + sep + appData.AndroidVersion;
        }
    }






}
