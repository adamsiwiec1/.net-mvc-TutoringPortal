using Fall2020AppGroup12.Models.AppUserModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020AppGroup12.Models.ViewModels;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.TicketModel;
using static Fall2020AppGroup12.Models.Charts.PieChart;
using Newtonsoft.Json;

namespace Fall2020AppGroup12.Controllers
{
    public class AdminController : Controller
    {

        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        private IMajorRepo iMajorRepo;
        private ITicketRepo iTicketRepo;
        private IApplicationUserRepo iApplicationUserRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;

        public AdminController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null, ITutorCourseRepo tutorCourseRepo = null, IMajorRepo majorRepo = null, ITicketRepo ticketRepo= null, IApplicationUserRepo applicationUserRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
            this.iMajorRepo = majorRepo;
            this.iTicketRepo = ticketRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
            this.iApplicationUserRepo = applicationUserRepo;

        }

        /* Misc Methods */

        public void LoadTicketChart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<Ticket> allTickets = iTicketRepo.ListAllTickets();
            List<Ticket> openTickets = iTicketRepo.ListAllOpenTickets();
            List<Ticket> inProgressTickets = iTicketRepo.ListAllInProgressTickets();
            List<Ticket> closedTickets = iTicketRepo.ListAllClosedTickets();

            // Get percentages
            float allTicketsCount = allTickets.Count;
            float openTicketsCount = openTickets.Count / allTicketsCount;
            float inProgressTicketsCount = inProgressTickets.Count / allTicketsCount;
            float closedTicketsCount = closedTickets.Count / allTicketsCount;

            dataPoints.Add(new DataPoint("Open Tickets", openTicketsCount));
            dataPoints.Add(new DataPoint("In Progress Tickets", inProgressTicketsCount));
            dataPoints.Add(new DataPoint("Closed Tickets", closedTicketsCount));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        }


        public IActionResult TestView()
        {

            string userId = iApplicationUserRepo.FindLoggedInUser();
            ApplicationUser user = iApplicationUserRepo.FindApplicationUser(userId);
            
            return View(user);
        }


        /* Basic Admin Functions */

        public IActionResult AdminHome()
        {
            LoadTicketChart();
            return View();
        }


        /* Complex Admin Functions */




        /* Admin List All Functions - Allows them to Edit and Delete */



        public IActionResult ListAllDepartments()
        {
            List<Department> allDepartments = iDepartmentRepo.ListAllDepartments();

            return View(allDepartments);
        }

        public IActionResult ListAllCourses()
        {
            List<Course> allCourses = iCourseRepo.ListAllCourses();

            return View(allCourses);
        }

        public IActionResult ListAllDiscussions()
        {
            List<Discussion> allDiscussions = iDiscussionRepo.ListAllDiscussions();
            return View(allDiscussions);
        }

        public IActionResult ListAllResponses()
        {
            List<Response> allResponses = iResponseRepo.ListAllResponses();

            return View(allResponses);
        }

        public IActionResult ListAllComments()
        {
            List<Comment> allComments = iCommentRepo.ListAllComments();

            return View(allComments);
        }


        public IActionResult ListAllTickets()
        {
            List<Ticket> allTickets = iTicketRepo.ListAllTickets();

            if (allTickets != null)
            {
                // Link Ticket & Student
                foreach (Ticket eachTicket in allTickets)
                {
                    if (eachTicket.StudentId != null)
                    {
                        eachTicket.Student = iStudentRepo.FindStudent(eachTicket.StudentId);
                    }
                    if (eachTicket.TutorId != null)
                    {
                        eachTicket.Tutor = iTutorRepo.FindTutor(eachTicket.TutorId);
                    }
                }
            }
            return View(allTickets);
        }


        public IActionResult ListAllMajors()
        {
            List<Major> allMajors = iMajorRepo.ListAllMajors();

            foreach (Major major in allMajors)
            {
                major.Department = iDepartmentRepo.FindDepartment(major.DepartmentID);

                try
                {
                    major.TutorsInMajor = iTutorRepo.ListAllTutors().Where(t => t.MajorID == major.MajorID).ToList();
                }
                catch { }
                try
                {
                    major.StudentsInMajor = iStudentRepo.ListAllStudents().Where(s => s.MajorID == major.MajorID).ToList();
                }
                catch { }
            }

            return View(allMajors);
        }

    }
}
