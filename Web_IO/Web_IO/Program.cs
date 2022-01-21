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
            char seperator = ';';
            #endregion

            #region ReadDatasFromWebFile
            string[] commentLine = DataLoader.ReadDatasFromFirstLine(adressHeFIAP, seperator);
            AppData[] healthFitnessApp = DataLoader.ReadFromFile(adressHeFIAP, seperator);
            AppData[] photographyApp = DataLoader.ReadFromFile(adressPhoApp, seperator);
            AppData[] weatherApp = DataLoader.ReadFromFile(adressWeaApp, seperator);
            #endregion
            
            //TIPP: Zum Zerlegen eines Textes x in einzelne Zeilen kann die Funktion x.Split('\n') verwendet werden. \n ist das Kürzel für NewLine
        }
        public static void MainMenu()
        {

        }
        public static void PrintErrorMessage(int errorCode)
        {
            #region errorCodes
            if (errorCode != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, an exeption case has happened");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }


            if (errorCode == 1)
            {
                Console.WriteLine("The argument is null or empty");
            }
            if (errorCode == 2)
            {
                Console.WriteLine("The argument is invalid");
            }
            if (errorCode == 3)
            {
                Console.WriteLine("The path cannot be found");
            }
            if (errorCode == 4)
            {
                Console.WriteLine("The filepath is too long");
            }
            if (errorCode == 5)
            {
                Console.WriteLine("You are not authorized for this action");
            }
            if (errorCode == 6)
            {
                Console.WriteLine("The file cannot be found or is opened");
            }
            if (errorCode == 7)
            {
                Console.WriteLine("Unexpectet I/O exeption");
            }
            if (errorCode == 8)
            {
                Console.WriteLine("General exeption happened. Please contact your admin");
            }
            if (errorCode == 9)
            {
                Console.WriteLine("The Format cannot be parsed");
            }
            if (errorCode == 10)
            {
                Console.WriteLine("The value is overflowed");
            }
            if (errorCode == 11)
            {
                Console.WriteLine("The index off the array is out of the arrayrange");
            }
            if (errorCode == 12)
            {
                Console.WriteLine("The method is not supported");
            }
            if (errorCode == 13)
            {
                Console.WriteLine("The system exepted a security failure");
            }
            if (errorCode == 14)
            {
                Console.WriteLine("The system is out of memory. The programm cannt run further");
            }
            if (errorCode == 15)
            {
                Console.WriteLine("The argument is out of range");
            }
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
    }
}
