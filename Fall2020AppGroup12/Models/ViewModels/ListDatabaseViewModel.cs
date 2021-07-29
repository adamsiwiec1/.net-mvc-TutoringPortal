using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.ResponseModel;
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
    public class ListDatabaseViewModel
    {
        public List<Department> Departments { get; set; }

        public List<Course> Courses { get; set; }

        public List<Discussion> Discussions { get; set; }

        public List<Response> Responses { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Major> Majors { get; set; }

        public List<Student> Students { get; set; }
        public List<Tutor> Tutors { get; set; }

        public List<Ticket> AllTickets { get; set; }

        public List<Ticket> OpenTickets { get; set; }

        public List<Ticket> InProgressTickets { get; set; }

        public List<Ticket> ClosedTickets { get; set; }

        public List<TutorCourse> TutorCourses { get; set; }

        public ListDatabaseViewModel(List<Department> departments, List<Course> courses, List<Discussion> discussions, List<Response> responses, List<Comment> comments, List<Major> majors, List<Student> students, List<Tutor> tutors, List<Ticket> allTickets, List<Ticket> openTickets, List<Ticket> inProgressTickets, List<Ticket> closedTickets, List<TutorCourse> tutorCourses)
        {
            Departments = departments;
            Courses = courses;
            Discussions = discussions;
            Responses = responses;
            Comments = comments;
            Majors = majors;
            Students = students;
            Tutors = tutors;
            AllTickets = allTickets;
            OpenTickets = openTickets;
            InProgressTickets = inProgressTickets;
            ClosedTickets = closedTickets;
            TutorCourses = tutorCourses;
        }

        public ListDatabaseViewModel()
        {

        }
    }
}
