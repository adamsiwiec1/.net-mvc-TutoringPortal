using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TicketModel
{
    public interface ITicketRepo
    {

        // List All
        List<Ticket> ListAllTickets();
        List<Ticket> ListAllOpenTickets();
        List<Ticket> ListAllInProgressTickets();
        List<Ticket> ListAllClosedTickets();

        // Add
        void AddTicket(Ticket ticket);

        // Edit
        void EditTicket(Ticket ticket);

        // Delete
        void DeleteTicket(Ticket ticket);

        Ticket FindTicket(int? ticketID);

    }
}
