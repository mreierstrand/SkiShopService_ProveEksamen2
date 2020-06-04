using System;
using SkiShopService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ConsumingRest_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAndPrintSki(SkiWebApi);
            GetSkiId(SkiWebApiID, 1);

            Console.ReadKey();

        }

        public static string SkiWebApi = "https://skishopserviceeksamen.azurewebsites.net/api/ski";
        

        private static void GetAndPrintSki(string SkiWebApi)
        {
            Console.WriteLine("GET ALL ITEMS \n");
            List<Ski> Skis = new List<Ski>();
            try
            {
                Task<List<Ski>> callTask = Task.Run(() => GetSki(SkiWebApi));
                callTask.Wait();
                Skis = callTask.Result;
                for (int i = 0; i < Skis.Count; i++)
                {
                    Console.WriteLine(Skis[i].Id + " " + Skis[i].SkiLength + " " + Skis[i].SkiType + " " + Skis[i].Price);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string SkiWebApiID = "https://skishopserviceeksamen.azurewebsites.net/api/ski";

        private static void GetSkiId(string uri, int id)
        {
            Console.WriteLine("\nGET SKI ID");
            List<Ski> skis = new List<Ski>();
            try
            {
                Task<List<Ski>> callTask = Task.Run(() => GetSki(SkiWebApiID));
                callTask.Wait();
                skis = callTask.Result;

                foreach (Ski s in skis)
                {
                    if (s.Id == id) Console.WriteLine(s.Id + " " + s.SkiLength + " " + s.SkiType + " " + s.Price);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static async Task<List<Ski>> GetSki(string SkiWebApi)
        {
            using (HttpClient client = new HttpClient())
            {
                string eventJsonString = await client.GetStringAsync(SkiWebApi);
                if (eventJsonString != null)
                    return (List<Ski>)JsonConvert.DeserializeObject(eventJsonString, typeof(List<Ski>));
                return null;
            }
        }
    }
}

