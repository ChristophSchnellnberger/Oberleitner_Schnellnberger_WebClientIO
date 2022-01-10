using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web_IO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region WebAdresses
            string adressHeFIAP = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/HealthFitnessApps.CSV";
            string adressPhoApp = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/PhotographyApps.CSV";
            string adressWeaApp = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/WeatherApps.CSV";
            #endregion

            #region ReadDatasFromWebFile
            AppData[] healthFitnessApp = DataLoader.ReadFromFile(adressHeFIAP);
            AppData[] photographyApp = DataLoader.ReadFromFile(adressPhoApp);
            AppData[] weatherApp = DataLoader.ReadFromFile(adressWeaApp);
            #endregion

            //TIPP: Zum Zerlegen eines Textes x in einzelne Zeilen kann die Funktion x.Split('\n') verwendet werden. \n ist das Kürzel für NewLine
        }

    }
}
