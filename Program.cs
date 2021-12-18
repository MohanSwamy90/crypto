using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Crypto
{
    internal class Program
    {
        private static string API_KEY = "e3738b41-b458-46c1-8d2e-4de15f09e11a";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting timer with callback every 5 minutes.");

                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(60*5);

                var timer = new System.Threading.Timer((e) =>
                {
                    displayCrypt();
                    Console.WriteLine("-----------------'");
                }, null, startTimeSpan, periodTimeSpan);

                Console.WriteLine("Done. Press ENTER");

                Console.ReadLine();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string makeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/new");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }

        private static void displayCrypt()
        {
            string result = makeAPICall();
            Cryptdata objCryptData = new Cryptdata();
            var jsonData1 = JsonConvert.DeserializeObject<CryptoData>(result);
            var currentDate = DateTime.UtcNow.Date;
            foreach (var crypt in jsonData1.data)
            {
                if (currentDate == DateTime.Parse(crypt.date_added).ToUniversalTime().Date)
                {
                    Console.WriteLine($"name: {crypt.name} - symbol: {crypt.symbol} - slug: {crypt.slug} - dateAdded: {crypt.date_added} - lastupdated: {crypt.last_updated} -platform-name: {crypt.platform.name} -platform-token: {crypt.platform.token_address}");
                }
            }
        }

        private static void callback(object state)
        {
            displayCrypt();
        }
    }
}