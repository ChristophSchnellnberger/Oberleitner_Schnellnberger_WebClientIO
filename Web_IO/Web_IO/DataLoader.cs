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
        public static string[] ReadDatasFromFirstLine(string adressWeb, char seperator)
        {
            string[] commentLine = new string[0];
            int error = 0;

            try
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(adressWeb);
                Stream contentStream = client.OpenRead(adressWeb);
                StreamReader reader = new StreamReader(contentStream);
                string firstLine = reader.ReadLine();
                string[] place = firstLine.Split(seperator);
                commentLine = new string[place.Length];
                int i = 0;
                
                if (firstLine.Contains(",,"))
                {
                    firstLine = firstLine.Replace(",,", ",0,");
                }              
                foreach (string placeItem in place)
                {
                    commentLine[i] = placeItem;
                    i++;
                }
                return commentLine;
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
                readDatas.Rating = place[2];
                string reducedReviews = place[3].Replace("M",string.Empty);
                readDatas.Reviews = reducedReviews;
                readDatas.Size = place[4];
                string reducedInstall = place[5].Replace(",", "");
                readDatas.Installs = reducedInstall;
                readDatas.Type = (Enums.Type)Enum.Parse(typeof(Enums.Type), place[6]);
                readDatas.Price = place[7];
                readDatas.ContentRating = place[8];
                string reducedGenre = place[9].Replace("&",string.Empty);
                reducedGenre= reducedGenre.Replace(" ",string.Empty);
                readDatas.Genres = reducedGenre;
                readDatas.LastUpdated = place[10];
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
            int error = 0;

            try
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(adressWeb);
                Stream contentStream = client.OpenRead(adressWeb);
                StreamReader reader = new StreamReader(contentStream);
                int value = 0;

                while (reader.Peek() != -1)
                {
                    //Read first line
                    for (int i = value; i < 1; i++)
                    {
                        string firstLine = reader.ReadLine();
                        value++;
                    }
                    //Read other lines
                    string line = reader.ReadLine();
                    AppData readProducts = ReadDatasFromCsv(line, seperator);
                    list.Add(readProducts);
                }
            }
            #region catches
            catch (Exception ex)
            {
                error = GetErrorCodeFromExeption(ex);
            }

            Program.PrintErrorMessage(error);
            #endregion



            return list.ToArray();
        }
        public static void WriteProductsToFile(string filePath, AppData[] appsToWrite,string[] firstLine,char seperator)
        {
            int error = 0;
            try
            {
                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach(var word in firstLine)
                    {
                        writer.Write(word);
                        writer.Write(seperator);
                    };
                    writer.WriteLine();
                    foreach (var app in appsToWrite)
                    {
                        writer.WriteLine(app.ToCsvString(seperator, app));
                    }
                }
            }
            #region catches
            catch (Exception ex)
            {
                error = GetErrorCodeFromExeption(ex);
            }

            Program.PrintErrorMessage(error);
            #endregion

        }
        public static AppData[] ProcessingUserInput(int[] choosenNumbers, AppData[] healthFitnessApp, AppData[] photographyApp, AppData[] weatherApp)
        {
            AppData[] currentArray = healthFitnessApp;
            List<AppData> returnList = new List<AppData>();
            int lowerBound = choosenNumbers[2];
            int upperBound = choosenNumbers[3];          
            int i = 0;
            bool conversionSuccessful = false;

            switch (choosenNumbers[0])
            {
                case 0:
                    {
                        currentArray = photographyApp;                       
                        break;
                    }
                case 1:
                    {
                        currentArray = weatherApp;
                        break;
                    }
                case 2:
                    {
                        currentArray = healthFitnessApp;
                        break;
                    }
                case 3 :
                    {
                        List<AppData> allApps = new List<AppData>();

                        foreach (AppData appData in photographyApp)
                        {
                            allApps.Add(appData);
                        }
                        foreach (AppData appData in weatherApp)
                        {
                            allApps.Add(appData);
                        }
                        foreach(AppData appData in healthFitnessApp)
                        {
                            allApps.Add(appData);
                        }
                        currentArray = allApps.ToArray();
                        break;
                    }
            }

            switch (choosenNumbers[1])
            {
                case 3:
                    {
                        for (i = 0; i < currentArray.Length; i++)
                        {
                            conversionSuccessful = int.TryParse(currentArray[i].Reviews,out int valueReview);

                            if (conversionSuccessful)
                            {
                                if (valueReview <= upperBound && valueReview >= lowerBound)
                                {
                                    returnList.Add(currentArray[i]);
                                }
                            }                                            
                        }
                        break;
                    }

                case 7:
                    {
                        
                        foreach(var item in currentArray)
                        {
                            conversionSuccessful = int.TryParse(currentArray[i].Price, out int valuePrice);

                            if (conversionSuccessful)
                            {
                                if (valuePrice <= upperBound && valuePrice >= lowerBound)
                                {
                                    returnList.Add(currentArray[i]);
                                }
                            }
                            i++;
                        }
                        
                        break;
                    }
                case 4:
                    {
                        conversionSuccessful = int.TryParse(currentArray[i].Size, out int valueSize);

                        if (conversionSuccessful)
                        {
                            if (valueSize <= upperBound && valueSize >= lowerBound)
                            {
                                returnList.Add(currentArray[i]);
                            }
                        }
                        break;
                    }
            }
           
            return returnList.ToArray();
        }
        private static int GetErrorCodeFromExeption(Exception exception)
        {
            if (exception is IOException)
            {
                return 7;
            }
            if (exception is ArgumentException)
            {
                return 2;
            }
            if (exception is ArgumentNullException)
            {
                return 1;
            }
            if (exception is ArgumentOutOfRangeException)
            {
                return 15;
            }
            if (exception is FormatException)
            {
                return 9;
            }
            if (exception is OutOfMemoryException)
            {
                return 14;
            }
            if (exception is OverflowException)
            {
                return 10;
            }
            if (exception is WebException)
            {
                return 16;
            }
            if (exception is NotSupportedException)
            {
                return 12;
            }
            return -1;
        }
    }
}
