using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Square;
using Square.Models;
using Square.Apis;
using Square.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Fall2020AppGroup12.Models.SquareModels
{
    public class ProcessPaymentModel
    {
        private SquareClient client;
        private string locationId;

        public string ResultMessage { get; set; }

        public ProcessPaymentModel(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            // Get environment
            Square.Environment environment = configuration["AppSettings:Environment"] == "sandbox" ?
                Square.Environment.Sandbox : Square.Environment.Production;

            // Build base client
            client = new SquareClient.Builder()
                .Environment(environment)
                .AccessToken(configuration["AppSettings:AccessToken"])
                .Build();

            locationId = configuration["AppSettings:LocationId"];
        }

       

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}