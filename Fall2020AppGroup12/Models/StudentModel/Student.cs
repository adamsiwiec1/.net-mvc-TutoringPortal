using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.TicketModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.StudentModel
{
    public class Student : ApplicationUser
    {
        [Required]
        public string StudentBiography { get; set; }
        [Required]
        public string StudentGraduationDate { get; set; }

        public List<Ticket> StudentTickets { get; set; }

        public Student(string firstname, string lastname, string address, string phoneNumber, string email, string password,int majorID, string stuBiography, string stuGraduationDate) : base(firstname, lastname, address, phoneNumber, email, password, majorID)
        {
            this.StudentBiography = stuBiography;
            this.StudentGraduationDate = stuGraduationDate;
            this.StudentTickets = new List<Ticket>();
        }

        public Student() { }

    }


}