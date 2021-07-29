using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TicketModel
{

    public class Ticket
    {
        private ICourseRepo iCourseRepo;

        [Key]
        public int TicketID { get; set; }

        [Required(ErrorMessage ="You must enter a ticket name.")]
        public string TicketName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Ticket status must be set.")]
        public string TicketStatus { get; set; }

        [Required(ErrorMessage = "Course code is required.")]
        public string CourseCode { get; set; }

        //[Required(ErrorMessage = "Subdivision is required.")]
        public string Subdivision { get; set; }

        //[Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public double? SessionRating { get; set; }

        [Required(ErrorMessage = "A ticket must be assigned to a student.")]
        public string StudentId { get; set; }

        // A student can submit a ticket and not have it picket up by a tutor yet
        public string TutorId { get; set; }

        public int? CourseID { get; set; }

        public decimal? TicketCost { get; set; }

        public bool? TicketPaid { get; set; }

        [Required]
        public bool? Closed { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("TutorId")]
        public Tutor Tutor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }



        public Ticket(string ticketName, string subdivision = null, string description = null, 
            double? sessionRating = null, string applicationUserIdStudent = null, 
            string applicationUserIdTutor = null, string ticketStatus = null, decimal? ticketCost = null, bool? ticketPaid = null, bool? closed = false, 
            int? courseID = null, ICourseRepo courseRepo = null) //Tutor ID is null because when a student creates a ticket, there is no tutor assigned yet. Ticket details also can be created afterward.
        {
            this.TicketName = ticketName;
            this.DateCreated = DateTime.Now;
            this.iCourseRepo = courseRepo;
            this.CourseCode = iCourseRepo.FindCourse(courseID).CourseCode;
            this.Subdivision = subdivision;
            this.Description = description;
            this.SessionRating = sessionRating;
            this.StudentId = applicationUserIdStudent;
            this.TutorId = applicationUserIdTutor;
            this.TicketStatus = ticketStatus;
            this.TicketCost = ticketCost;
            this.TicketPaid = ticketPaid;
            this.Closed = closed;
            this.CourseID = courseID;
        }

        public Ticket(){}

    }
}
