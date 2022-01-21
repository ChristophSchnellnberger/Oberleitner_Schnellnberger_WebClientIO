using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web_IO
{
    internal class DataLoader
    {
        static void MainDataLoader()
        {
            //Die Klasse DataLoader soll unter Angabe eines Links die Daten laden und als Array oder Liste von AppData Objekten zurückgeben
            //Die Klasse DataLoader soll unter Angabe von Max- oder Min Werten für das Property Price, Reviews und/oder Size
            //nur jene Daten zurückgeben welche dem Filterkriterium entsprechen
        }

        public static string[] ReadDatasFromFirstLine(string adressWeb, char seperator)
        {          
            WebClient client = new WebClient();
            string content = client.DownloadString(adressWeb);
            Stream contentStream = client.OpenRead(adressWeb);
            StreamReader reader = new StreamReader(contentStream);
            string firstLine = reader.ReadLine();           
            string[] place = firstLine.Split(seperator);
            string[] commentLine = new string[place.Length];
            int i = 0;
            int error = 0;

            try
            {
                if (firstLine.Contains(",,"))
                {
                    firstLine = firstLine.Replace(",,", ",0,");
                }              
                foreach (string placeItem in place)
                {
                    commentLine[i] = placeItem;
                    i++;
                }
            }
            #region catches
            catch (Exception ex)
            {
                error = GetErrorCodeFromExeption(ex);
            }
            Program.PrintErrorMessage(error);
            #endregion
            return commentLine;
        }
        public static AppData ReadDatasFromCsv(string csvString, char seperator)
        {
            int error = 0;
            AppData readDatas = new AppData();

            try
            {
                if (csvString.Contains(",,"))
                {
                    csvString = csvString.Replace(",,", ",0,");
                }
                string[] place = csvString.Split(seperator);
                readDatas.App = place[0];
                readDatas.Category = place[1];
                readDatas.Rating = int.Parse(place[2]);
                readDatas.Reviews = int.Parse(place[3]);
                readDatas.Size = place[4];
                string reducedInstall = place[5].Replace(",", "");
                readDatas.Installs = double.Parse(reducedInstall.Trim('+'));
                readDatas.Type = (Enums.Type)Enum.Parse(typeof(Enums.Type), place[6]);
                readDatas.Price = double.Parse(place[7].Replace('.', ','));
                readDatas.ContentRating = place[8];
                string reducedGenre = place[9].Replace("&",string.Empty);
                reducedGenre= reducedGenre.Replace(" ",string.Empty);
                readDatas.Genres = (Enums.Genres)Enum.Parse(typeof(Enums.Genres), reducedGenre);
                readDatas.LastUpdated = DateTime.Parse(place[10]);
                readDatas.CurrentVersion = place[11];
                readDatas.AndroidVersion = place[12];
            }
            #region catches
            catch (Exception ex)
            {
                error = GetErrorCodeFromExeption(ex);
            }

            Program.PrintErrorMessage(error);
            #endregion
            return readDatas;
        }
        public static AppData[] ReadFromFile(string adressWeb,char seperator)
        {
            List<AppData> list = new List<AppData>();

            WebClient client = new WebClient();
            string content = client.DownloadString(adressWeb);
            Stream contentStream = client.OpenRead(adressWeb);
            StreamReader reader = new StreamReader(contentStream);
            int value = 0;
            
            while (reader.Peek() != -1)
            {
                //Read first line
                for (int i = value; i < 1;i++)
                {      
                    string firstLine = reader.ReadLine();
                    value++;
                }

                //Read other lines
                string line = reader.ReadLine();
                AppData readProducts = ReadDatasFromCsv(line, seperator);              
            }


            //Laden der Daten mit dem WebClient aus 3 Datenquellen (entspricht 3 Kategorien von Apps)
            // Eingabe der Filterkriterien in der Console für alle Apps(oder auf Wunsch auf kategoriespezifisch)
            //Ausgabe der Daten aller 3 Datenquellen am Bildschirm und in eine(!) Datei
            //Option für Profis / Fleißaufgabe
            //Integrieren Sie den DataLoader in Ihren Webshop zum Einkaufen von Apps über ihr Webshop Programm

            return list.ToArray();
        }
        private static int GetErrorCodeFromExeption(Exception exception)
        {
            if (exception is IOException)
            {
                return 1;
            }

            return -1;
            //            #region catches
            //catch (ArgumentOutOfRangeException)
            //{
            //    error = 15;
            //}
            //catch (ArgumentNullException)
            //{
            //    error = 1;
            //}
            //catch (ArgumentException)
            //{
            //    error = 2;
            //}
            //catch (OutOfMemoryException)
            //{
            //    error = 14;
            //}
            //catch (FormatException)
            //{
            //    error = 9;
            //}
            //catch (OverflowException)
            //{
            //    error = 10;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    error = 11;
            //}
            //catch (NotSupportedException)
            //{
            //    error = 12;
            //}
            //catch (DirectoryNotFoundException)
            //{
            //    error = 3;
            //}
            //catch (PathTooLongException)
            //{
            //    error = 4;
            //}
            //catch (UnauthorizedAccessException)
            //{
            //    error = 5;
            //}
            //catch (System.Security.SecurityException)
            //{
            //    error = 13;
            //}
            //catch (FileNotFoundException)
            //{
            //    error = 6;
            //}
            //catch (IOException)
            //{
            //    error = 7;
            //}
            //catch (Exception)
            //{
            //    error = 8;
            //}

            //Program.Exeptions(error);
            //#endregion


        }
        public static void ProcessingUserInput(int[] choosenNumbers, AppData[] healthFitnessApp, AppData[] photographyApp, AppData[] weatherApp)
        {

        }
    }
}
