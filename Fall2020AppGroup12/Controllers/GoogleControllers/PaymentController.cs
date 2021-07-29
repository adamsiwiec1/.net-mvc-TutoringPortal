using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.ViewModelsMain;
using Fall2020AppGroup12.Models.SquareModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Square;
using Square.Apis;
using Square.Exceptions;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Controllers
{
    public class PaymentController : Controller
    {
        private IApplicationUserRepo iApplicationUserRepo;
        private ITicketRepo iTicketRepo;
        private Microsoft.Extensions.Configuration.IConfiguration iConfig;

        public PaymentController(ITicketRepo ticketRepo, IApplicationUserRepo appUserRepo, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            iTicketRepo = ticketRepo;
            iConfig = configuration;
            iApplicationUserRepo = appUserRepo;

            // Square
            // Get environment
            Square.Environment environment = configuration["AppSettings:Environment"] == "sandbox" ?
                Square.Environment.Sandbox : Square.Environment.Production;

            // Build base client
            client = new SquareClient.Builder()
                .Environment(environment)
                .AccessToken(configuration["AppSettings:AccessToken"])
                .Build();

            //locationId = configuration["AppSettings:LocationId"];

            // End Square
        }

        // Square Instance Variables
        private SquareClient client;
        //private string locationId;
        public string ResultMessage { get; set; }

        public IActionResult SquareTest()
        {
            SquareModel square = new SquareModel(iConfig);

            PaymentViewModel viewModel = new PaymentViewModel();
            viewModel.Square = square;

            return View(viewModel);
        }

        // This is used for Students
        public IActionResult MakeTicketPayment(int ticketID)
        {

                PaymentViewModel viewModel = new PaymentViewModel();

                SquareModel square = new SquareModel(iConfig);
                viewModel.Square = square;
                viewModel.Ticket = iTicketRepo.FindTicket(ticketID);

                string userId = iApplicationUserRepo.FindLoggedInUser();
                viewModel.User = iApplicationUserRepo.FindApplicationUser(userId);
                return View(viewModel);

        }

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }

        public IActionResult ProcessPayment(int ticketID)
        {
            if (ModelState.IsValid) //this is not working
            {
                // Set ticket to paid

                Ticket ticket = iTicketRepo.FindTicket(ticketID);

                ticket.TicketPaid = true;
                //ticket.DatePaid or new table transaction.DatePaid

                iTicketRepo.EditTicket(ticket);


                // End of Adam Function

                string nonce = Request.Form["nonce"];
                IPaymentsApi PaymentsApi = client.PaymentsApi;
                // Every payment you process with the SDK must have a unique idempotency key.
                // If you're unsure whether a particular payment succeeded, you can reattempt
                // it with the same idempotency key without worrying about double charging
                // the buyer.
                string uuid = NewIdempotencyKey();

                //// Get the currency for the location
                //RetrieveLocationResponse locationResponse = await client.LocationsApi.RetrieveLocationAsync(locationId: locationId);
                //string currency = locationResponse.Location.Currency;

                // Monetary amounts are specified in the smallest unit of the applicable currency.
                // This amount is in cents. It's also hard-coded for $1.00,
                // which isn't very useful.
                Money amount = new Money.Builder()
                    .Amount(500L)
                    .Currency("USD")
                    .Build();

                // To learn more about splitting payments with additional recipients,
                // see the Payments API documentation on our [developer site]
                // (https://developer.squareup.com/docs/payments-api/overview).
                CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest.Builder(nonce, uuid, amount)
                    .Note("From Square Sample Csharp App")
                    .Build();

                try
                {
                    CreatePaymentResponse response = PaymentsApi.CreatePayment(createPaymentRequest);
                    ResultMessage = "Payment complete! " + response.Payment.Note;
                }
                catch (ApiException e)
                {
                    ResultMessage = e.Message;
                }

                // Return payment confirmation for ticket
                return View(ticket);
            }
            else
            {
                return View("MakeTicketPayment", ticketID);
            }
        }
    }
}
