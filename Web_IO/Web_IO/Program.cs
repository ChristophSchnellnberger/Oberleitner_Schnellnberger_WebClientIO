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
            string filteredAppsCsv = "Filtered_Apps.csv";
            char seperator = ';';
            #endregion

            #region ReadDatasFromWebFile
            string[] commentLine = DataLoader.ReadDatasFromFirstLine(adressHeFIAP, seperator);
            AppData[] healthFitnessApp = DataLoader.ReadFromFile(adressHeFIAP, seperator);
            AppData[] photographyApp = DataLoader.ReadFromFile(adressPhoApp, seperator);
            AppData[] weatherApp = DataLoader.ReadFromFile(adressWeaApp, seperator);
            #endregion

            #region User interaction
            Greeting();
            int[] chosenNumbers = MainMenu(commentLine, healthFitnessApp, photographyApp, weatherApp);
            AppData[] filteredDatas = DataLoader.ProcessingUserInput(chosenNumbers, healthFitnessApp, photographyApp, weatherApp);
            DataLoader.WriteProductsToFile(filteredAppsCsv,filteredDatas,commentLine,seperator);
            PlotFilteredDatas(filteredDatas);
            #endregion
        }
        private static void Greeting()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to our Web I/O program");
            Console.WriteLine();
            Console.WriteLine("All datas has been read out");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press enter for further actions");
            Console.ReadLine();
            Console.Clear();
        }
        private static int[] MainMenu(string[] commentLine, AppData[] healthFitnessApp, AppData[] photographyApp, AppData[] weatherApp)
        {
            Console.WriteLine("MAINMENU");
            Console.WriteLine();
            bool choosement = false;
            int[] choosenValues = new int[4];
            int error = 0;

            #region choose genre
            do
            {
                try
                {
                    Console.WriteLine("Press \"0\" for " + Enums.Genres.Photography);
                    Console.WriteLine();
                    Console.WriteLine("Press \"1\" for " + Enums.Genres.Weather);
                    Console.WriteLine();
                    Console.WriteLine("Press \"2\" for " + Enums.Genres.HealthFitness);
                    Console.WriteLine();
                    Console.WriteLine("Press \"3\" to filter for all genres");
                    Console.WriteLine();
                    choosenValues[0] = int.Parse(Console.ReadLine());
                    Console.Clear();
                    choosement = CheckIfUserIsSure(0);
                }
                #region catches
                catch (Exception ex)
                {
                     error = GetErrorCodeFromExeption(ex);
                    choosement = false;
                    Program.PrintErrorMessage(error);
                }
               
                #endregion


            }
            while (choosement==false);

            #endregion

            #region choose filterType
            do
            {
                try
                {
                    int i = 0;

                    foreach (string comment in commentLine)
                    {
                        if (i == 3 || i == 4 || i == 7)
                        {
                            Console.WriteLine("Press " + i + " for " + comment);
                            Console.WriteLine();
                        }
                        i++;
                    }

                    Console.Write("Press the number of the type you want to filter: ");
                    string inputNumber = Console.ReadLine();
                    choosenValues[1] = int.Parse(inputNumber);
                    choosement = CheckIfUserIsSure(1);

                    if (choosenValues[1] == 7)
                    {
                        Console.WriteLine("Press \"1\" if you want to be shown free apps");
                        Console.WriteLine();
                        Console.WriteLine("Press \"2\" if you want to filter paid apps");
                        Console.WriteLine();
                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            choosenValues[2] = 0;
                            choosenValues[3] = 0;

                            return choosenValues;
                        }
                    }
                }
                #region catches
                catch (Exception ex)
                {
                    error = GetErrorCodeFromExeption(ex);
                    choosement = false;
                    Program.PrintErrorMessage(error);
                }
               
                #endregion


            }
            while (choosement == false);


            #endregion

            #region choose Min/Max value

            do
            {
                try
                {
                    Console.WriteLine("Please choose the lowerbound and upperbound of your filter");
                    Console.WriteLine();

                    Console.WriteLine("Please enter the min value: ");
                    choosenValues[2] = int.Parse(Console.ReadLine());
                    choosement = CheckIfUserIsSure(2);
                }
                #region catches
                catch (Exception ex)
                {
                    error = GetErrorCodeFromExeption(ex);
                    choosement = false;
                    Program.PrintErrorMessage(error);
                }

                #endregion
            }
            while (choosement == false);

            do
            {
                try
                {
                    Console.WriteLine("Please enter the max value: ");
                    choosenValues[3] = int.Parse(Console.ReadLine());
                    Console.Clear();
                    choosement = CheckIfUserIsSure(3);
                }
                #region catches
                catch (Exception ex)
                {
                    error = GetErrorCodeFromExeption(ex);
                    choosement = false;
                    Program.PrintErrorMessage(error);
                }
               
                #endregion
            }
            while (!choosement);           
            #endregion

            return choosenValues;
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
            if (errorCode == 16)
            {
                Console.WriteLine("Data interchange failed");
            }
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
        private static bool CheckIfUserIsSure(int value)
        {
            int error = 0;
            bool choosement = false;

            try
            {
                Console.Clear();
                Console.WriteLine("If you want to choose an other value press \"x\"");
                Console.WriteLine("Else press \"ENTER\"");
                string input = Console.ReadLine();
                input.Trim();
                input.ToLower();

                if (input == "x")
                {
                    choosement = false;
                }
                else
                {
                    choosement = true;
                }

            }
            #region catches
            catch (Exception ex)
            {
                error = GetErrorCodeFromExeption(ex);
            }
            Program.PrintErrorMessage(error);
            #endregion

            return choosement;
        }
        private static void PlotFilteredDatas(AppData[] filteredDatas)
        {
            Console.WriteLine("Here you can see your filtered apps: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The app's are from the category: " + filteredDatas[0].Genres);
            Console.WriteLine();
            int i = 1;
            foreach (AppData data in filteredDatas)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(i + ") ");
                Console.ResetColor();
                Console.WriteLine(data.App);
                Console.WriteLine("Reviews: " + data.Reviews);
                Console.WriteLine("Size: " + data.Size);
                Console.WriteLine("Installs: " + data.Installs);
                Console.WriteLine("Price: " + "$" + data.Price);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.ResetColor();
                i++;
            }

            Console.ReadLine();
          
        }
        private static int GetErrorCodeFromExeption(Exception exception)
        {
            if (exception is IOException)
            {
                return 7;
            }
            if(exception is ArgumentException)
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
            return -1;
        }

    }
}
