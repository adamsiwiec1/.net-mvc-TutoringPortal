using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.ViewModelsMain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepo iStudentRepo;
        private IMajorRepo iMajorRepo;
        private ICourseRepo iCourseRepo;
        private ITicketRepo iTicketRepo;

        public StudentController(IStudentRepo studentRepo, IMajorRepo majorRepo = null, ICourseRepo courseRepo = null, ITicketRepo ticketRepo = null)
        {
            this.iStudentRepo = studentRepo;
            this.iMajorRepo = majorRepo;
            this.iCourseRepo = courseRepo;
            this.iTicketRepo = ticketRepo;
        }

        public void AddTutor(Student student)
        {
            if (ModelState.IsValid)
            {
                iStudentRepo.AddStudent(student);
            }
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {

                string Id = iStudentRepo.AddStudent(student);
                return RedirectToAction("ListAllStudents");
            }
            else
            {
                ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");
                return View();
            }
        }


        public IActionResult ListAllStudents()
        {
            List<Student> allStudents = iStudentRepo.ListAllStudents();

            foreach(Student student in allStudents)
            {
                student.Major = iMajorRepo.FindMajor(student.MajorID);
            }

            return View(allStudents);
        }

        // Student Add Ticket

        [HttpGet]
        public IActionResult OpenNewTicket()
        {

            ViewData["StudentId"] = iStudentRepo.FindLoggedInStudent();
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");

            return View();
        }

        [HttpPost]
        public IActionResult OpenNewTicket(Ticket ticket)
        {
            Course course = iCourseRepo.FindCourse(ticket.CourseID);

            ticket.Closed = false;
            ticket.CourseCode = course.CourseCode;
            ticket.DateCreated = DateTime.Now;


            if (ticket != null)
            {
                // Add Ticket
                try
                {
                    iTicketRepo.AddTicket(ticket);
                    // Redirect to full list of Tickets
                    return RedirectToAction("MyTickets", "Student");
                }
                catch(Exception ex)
                { 
                    ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
                    return View();
                }

            }
            else
            {
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
                return View();
            }
        }


        public IActionResult MyTickets() 
        {
            TicketsViewModel viewModel = new TicketsViewModel();
            viewModel.OpenTickets = new List<Ticket>();
            viewModel.InProgressTickets = new List<Ticket>();
            viewModel.ClosedTickets = new List<Ticket>();

            viewModel.OpenTickets = iTicketRepo.ListAllOpenTickets();

            viewModel.InProgressTickets = iTicketRepo.ListAllInProgressTickets();

            viewModel.ClosedTickets = iTicketRepo.ListAllClosedTickets();
            
            return View(viewModel);

        }


        //public IActionResult MyTickets()
        //{
        //    List<Ticket> ticketList;
        //    ticketList = iTicketRepo.ListAllTickets();

        //}



    }
}
