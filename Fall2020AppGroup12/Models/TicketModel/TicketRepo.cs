using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TicketModel
{
    public class TicketRepo : ITicketRepo
    {
        private ApplicationDbContext database;

        private ITutorRepo iTutorRepo;
        private ICourseRepo iCourseRepo;

        public TicketRepo(ApplicationDbContext dbContext, ITutorRepo tutorRepo, ICourseRepo courseRepo) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
            iTutorRepo = tutorRepo;
            iCourseRepo = courseRepo;
        }

        // Add
        public void AddTicket(Ticket ticket)
        {
            database.Ticket.Add(ticket);
            database.SaveChanges();
        }


        // Edit
        public void EditTicket(Ticket ticket)
        {
            database.Ticket.Update(ticket);
            database.SaveChanges();
        }

        //Delete
        public void DeleteTicket(Ticket ticket)
        {
            database.Ticket.Remove(ticket);
            database.SaveChanges();
        }

        public Ticket FindTicket(int? ticketID)
        {
            return database.Ticket.Find(ticketID);

        }

        //List All
        public List<Ticket> ListAllTickets()
        {
            List<Ticket> tickets = database.Ticket.ToList();

            foreach (Ticket ticket in tickets)
            {
                ticket.Course = iCourseRepo.ListAllCourses().Where(c => c.CourseCode == ticket.CourseCode).FirstOrDefault();
                if (ticket.Course != null)
                {
                    ticket.CourseID = ticket.Course.CourseID;
                }
            }
            return tickets;
        }

        public List<Ticket> ListAllOpenTickets()
        {
            List<Ticket> tickets = database.Ticket.Where(t => t.TicketStatus == "Open").ToList();
            return tickets;
        }

        public List<Ticket> ListAllInProgressTickets()
        {
            List<Ticket> tickets = database.Ticket.Where(t => t.TicketStatus == "In Progress").ToList();
            return tickets;
        }

        public List<Ticket> ListAllClosedTickets()
        {
            List<Ticket> tickets = database.Ticket.Where(t => t.TicketStatus == "Closed").ToList();
            return tickets;
        }

    }
}
