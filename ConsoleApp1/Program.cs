using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Payload
        {
            public double high { get; set; }
            public string last { get; set; }
            public DateTime created_at { get; set; }
            public string book { get; set; }
            public string volume { get; set; }
            public string vwap { get; set; }
            public string low { get; set; }
            public string ask { get; set; }
            public string bid { get; set; }
            public string change_24 { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public Payload payload { get; set; }
        }


        static void Main(string[] args)
        {
            var client = new WebClient();
            string text = client.DownloadString("https://api.bitso.com/v3/ticker/?book=btc_mxn");

            Payload post = JsonConvert.DeserializeObject<Payload>(text);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(text);

            Console.WriteLine($"Precio mas alto: {myDeserializedClass.payload.high}");

            Console.WriteLine($"Precio mas bajo: { myDeserializedClass.payload.low}");

            Console.WriteLine($"Precio: { myDeserializedClass.payload.last}");

            Console.WriteLine(text);

        }
    }
}
