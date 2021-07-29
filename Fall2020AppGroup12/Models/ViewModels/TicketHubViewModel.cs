using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class TicketHubViewModel
    {
        public List<Ticket> Tickets { get; set; }

        public List<Tutor> Tutors { get; set; }

        public List<TutorCourse> TutorCourses { get; set; }

        public List<Student> Students { get; set; }

        public List<Major> Majors { get; set; }

        public List<Course> Courses { get; set; }

        public TicketHubViewModel(List<Ticket> tickets, List<Tutor> tutors, List<TutorCourse> tutorCourses, List<Student> students, List<Major> majors, List<Course> courses)
        {
            Tickets = tickets;
            Tutors = tutors;
            TutorCourses = tutorCourses;
            Students = students;
            Majors = majors;
            Courses = courses;
        }

        public TicketHubViewModel() { }
    }
}
