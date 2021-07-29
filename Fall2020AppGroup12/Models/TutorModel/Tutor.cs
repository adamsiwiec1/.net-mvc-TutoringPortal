using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TutorModel
{
    public class Tutor : ApplicationUser
    {
        [Required]
        public string TutorBiography { get; set; }
        [Required]
        public string TutorGraduationDate { get; set; }
        [Required]
        public int TutorRating { get; set; }

        public List<Ticket> TutorTickets { get; set; }

        public List<Course> QualifiedCourses { get; set; }

        public Tutor(string firstname, string lastname, string address, string phoneNumber, string email, string password, int majorID, string tutBiography, string tutGraduationDate, int tutRating) : base(firstname, lastname, address, phoneNumber, email, password, majorID)
        {
            this.TutorBiography = tutBiography;
            this.TutorGraduationDate = tutGraduationDate;
            this.TutorRating = tutRating;
            this.TutorTickets = new List<Ticket>();
            this.QualifiedCourses = new List<Course>();
        }

        public Tutor() { }

    }
}
