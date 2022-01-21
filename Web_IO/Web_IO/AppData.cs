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
        public int Rating { get; set; }
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

        #region methods
        static void MainAppData()
        {
            //Die Klasse AppData soll jeweils einen Datensatz aus den geladenen Daten repräsentieren (je 1 Zeile) mit den jeweiligen Properties.
            //App	Category	Rating	Reviews	Size	Installs	Type	Price	Content Rating	Genres	Last Updated	Current Ver	Android Ver






        }

        #endregion
    }






}
