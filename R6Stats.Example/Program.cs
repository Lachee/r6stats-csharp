using System;
using System.IO;

namespace R6Stats.Example
{
    class Program
    {
        static string key;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            key = File.ReadAllText("api.key");

            //Prepare the client
            var client = new R6Stats.R6StatsClient(key);

            //Get generic response
            var genericResponse = client.GetWeaponStatisticsAsync("KommadantKlink", Entities.Platform.PC).Result;
            Console.WriteLine(genericResponse.Username);


        }
    }
}
