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
            string adressHeFIAP = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/HealthFitnessApps.CSV";
            string adressPhoApp = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/PhotographyApps.CSV";
            string adressWeaApp = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/WeatherApps.CSV";


        }

        public static void Vorlage()
        {
            WebClient client = new WebClient();

            string adress = "https://fhwels.s3.eu-central-1.amazonaws.com/PRO1UE_WS21/testfile.txt";
            string content = client.DownloadString(adress);
            Stream contentStream = client.OpenRead(adress);
            StreamReader reader = new StreamReader(contentStream);

            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }

            string[] lines = content.Split('\n');

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            //Laden der Daten mit dem WebClient aus 3 Datenquellen (entspricht 3 Kategorien von Apps)
            // Eingabe der Filterkriterien in der Console für alle Apps(oder auf Wunsch auf kategoriespezifisch)
            //Ausgabe der Daten aller 3 Datenquellen am Bildschirm und in eine(!) Datei
            //Option für Profis / Fleißaufgabe
            //Integrieren Sie den DataLoader in Ihren Webshop zum Einkaufen von Apps über ihr Webshop Programm
        }
    }
}
