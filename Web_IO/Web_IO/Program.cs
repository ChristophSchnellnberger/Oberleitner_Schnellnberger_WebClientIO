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
        }
    }
}
