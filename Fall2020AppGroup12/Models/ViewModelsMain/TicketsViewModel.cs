using Fall2020AppGroup12.Models.TicketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModelsMain
{
    public class TicketsViewModel
    {
        public string StudentID { get; set; }
        public List<Ticket> OpenTickets { get; set; }

        public List<Ticket> InProgressTickets { get; set; }

        public List<Ticket> ClosedTickets { get; set; }


    }
}
