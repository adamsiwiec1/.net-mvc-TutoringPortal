using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.SquareModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModelsMain
{
    public class PaymentViewModel
    {
        public SquareModel Square { get; set; }

        public Ticket Ticket { get; set; }

        public ApplicationUser User { get; set; }

    }
}
