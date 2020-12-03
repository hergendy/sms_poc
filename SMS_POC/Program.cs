using RestSharp;
using System;
using System.Collections.Generic;

namespace SMS_POC
{
    class Program
    {
        private static RestClient _client;
        private const string BaseAddress = "https://seeme.hu/";
        private const string Path = "gateway";

        private static void Main(string[] args)
        {
            _client = new RestClient(BaseAddress);

            var request = new RestRequest(Path, Method.GET);

            var queryParams = new Dictionary<string, string>
            {
                //See https://seeme.hu/tudastar/reszletek/sms-gateway-parameterek
                {"key", "62s97ea6i0th3iafxpqu9733azmtqwinf8e3"},
                {"callback", "4,6,7"},
                { "format", "json"}
            };

            Console.WriteLine("Enter the message: \n");
            queryParams.Add("message", Console.ReadLine());
            Console.WriteLine("Enter the number like (36201234567): \n");
            queryParams.Add("number", Console.ReadLine());

            foreach (var (key, value) in queryParams)
                request.AddParameter(key, value);

            var response = _client.Execute(request);
        }
    }
}
