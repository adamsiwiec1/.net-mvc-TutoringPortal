using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.SquareModels
{
    public class SquareModel
    {
        public string PaymentFormUrl { get; set; }
        public string ApplicationId { get; set; }
        public string LocationId { get; set; }




        public SquareModel(IConfiguration configuration)
        {
            this.ApplicationId = configuration["AppSettings:ApplicationId"];
            this.LocationId = configuration["AppSettings:LocationId"];
            this.PaymentFormUrl = configuration["AppSettings:Environment"] == "sandbox" ?
                "https://js.squareupsandbox.com/v2/paymentform" : "https://js.squareup.com/v2/paymentform";
        }

    }
}
