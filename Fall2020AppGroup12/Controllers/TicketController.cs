using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020AppGroup12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Fall2020AppGroup12.Controllers
{
    public class TicketController : Controller
    {

        private ITicketRepo iTicketRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;
        private ICourseRepo iCourseRepo;
        private ITutorCourseRepo iTutorCourseRepo;
        private IMajorRepo iMajorRepo;
        private IDepartmentRepo iDepartmentRepo;

        public TicketController(ITicketRepo ticketRepo, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null, ICourseRepo courseRepo = null, ITutorCourseRepo tutorCourseRepo = null, IMajorRepo majorRepo = null, IDepartmentRepo departmentRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iCourseRepo = courseRepo;
            this.iTicketRepo = ticketRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
            this.iTutorCourseRepo = tutorCourseRepo;
            this.iMajorRepo = majorRepo;

        }

        ////Helper method - determines ticket status on creation dependent on factors - due to the fact users will not be entering this field when they create a ticket; it is in the background
        //public void GetTicketStatus(Ticket ticket )
        //{
        //    Ticket ticket = iTicketRepo.FindTicket(ticketID);

        //    if (TutorId == null) // If no tutor assigned, ticket is left 'Open'.
        //    {
        //        TicketStatus = "Open";
        //    }
        //    if (TutorId != null) // if tutor assigned, ticket is set to "in progress'
        //    {
        //        TicketStatus = "In Progress";
        //    }
        //    if (Closed == true) // if closed is set to true, ticket status is set to 'closed'
        //    {
        //        TicketStatus = "Closed";

        //    }
        //}


        // Add
        [HttpGet]  
        public IActionResult AddTicket()
        {
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
            ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult AddTicket(Ticket ticket) 
        {
            if (ModelState.IsValid)
            {
                // Add Ticket
                iTicketRepo.AddTicket(ticket);
                
                // Redirect to full list of Tickets
                return RedirectToAction("ListAllTicketsAdmin", "Ticket");
            }
            else
            {
                ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
                ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
                return View();
            }
        }

        // Edit
        [HttpGet]
        public IActionResult EditTicket(int? ticketID)
        {
            ViewData["AllTickets"] = new SelectList(iTicketRepo.ListAllTickets(), "TicketID", "TicketID", "StudentID");
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
            ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
            Ticket ticket = iTicketRepo.FindTicket(ticketID);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult EditTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                iTicketRepo.EditTicket(ticket);

                return RedirectToAction("ListAllTickets", "Admin");
            }
            else
            {
                ViewData["AllTickets"] = new SelectList(iTicketRepo.ListAllTickets(), "TicketID", "TicketID", "StudentID");
                ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
                ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseCode", "CourseCode");
                return View(ticket);
            }
        }

        // Delete
        public IActionResult ConfirmDeleteTicket(int? ticketID)
        {
            Ticket ticket = iTicketRepo.FindTicket(ticketID);
            return View(ticket);
        }

        public IActionResult DeleteTicket(Ticket ticket)
        {
            iTicketRepo.DeleteTicket(ticket);
            return RedirectToAction("ListAllTickets");
        }

        // List All
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




        public IActionResult ListAllOpenTickets()
        {
            List<Ticket> allTickets = iTicketRepo.ListAllTickets().Where(t => t.TicketStatus == "Open").ToList();

            return View(allTickets);
        }

        public IActionResult ListAllInProgressTickets()
        {
            List<Ticket> allTickets = iTicketRepo.ListAllTickets().Where(t => t.TicketStatus == "In Progress").ToList();

            return View(allTickets);
        }

        public IActionResult ListAllClosedTickets()
        {
            List<Ticket> allTickets = iTicketRepo.ListAllTickets().Where(t => t.TicketStatus == "Closed").ToList();

            return View(allTickets);
        }

        public IActionResult ShowTicketDetails(int ticketID)
        {
            Ticket ticket = iTicketRepo.FindTicket(ticketID);

            // get student
            ticket.Student = iStudentRepo.FindStudent(ticket.StudentId);

            // get tutor (if there is one)
            if (ticket.TutorId != null)
            {
                ticket.Tutor = iTutorRepo.FindTutor(ticket.TutorId);
            }

            return View(ticket);
        }


        // Complex Work Flows - Assign Qualified Tutor to Ticket

        // MainPage
        public IActionResult TicketHubMain(TicketHubViewModel viewModel)
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
            viewModel.Tickets = allTickets;

            List<Tutor> allTutors = iTutorRepo.ListAllTutors();
            foreach (Tutor tutor in allTutors)
            {
                tutor.Major = iMajorRepo.FindMajor(tutor.MajorID);
            }
            viewModel.Tutors = allTutors;


            List<TutorCourse> allTutorCourses = iTutorCourseRepo.ListAllTutorCourses();
            viewModel.TutorCourses = allTutorCourses;

            List<Student> allStudents = iStudentRepo.ListAllStudents();
            foreach (Student student in allStudents)
            {
                student.Major = iMajorRepo.FindMajor(student.MajorID);
            }
            viewModel.Students = allStudents;

            List<Major> allMajors = iMajorRepo.ListAllMajors();
            foreach (Major major in allMajors)
            {
                major.Department = iDepartmentRepo.FindDepartment(major.DepartmentID);
                major.TutorsInMajor = iTutorRepo.ListAllTutors().Where(t => t.MajorID == major.MajorID).ToList();
                major.StudentsInMajor = iStudentRepo.ListAllStudents().Where(s => s.MajorID == major.MajorID).ToList();
            }
            viewModel.Majors = allMajors;

            List<Course> allCourses = iCourseRepo.ListAllCourses();
            viewModel.Courses = allCourses;

            return View(viewModel);

        }


        // Nanda - Revised complex work flow 

        public IActionResult AssignQualifiedTutor(int ticketID)
        {
            Ticket ticket = iTicketRepo.FindTicket(ticketID);

            if (ticket != null)
            {
                List<TutorCourse> tutorCourses = iTutorCourseRepo.ListAllTutorCourses();
                tutorCourses = tutorCourses.Where(tc => tc.CourseID == ticket.CourseID).ToList();

                if (ModelState.IsValid)
                {
                    if (tutorCourses.Any())

                    {
                        ticket.TutorId = tutorCourses.First().TutorID;
                        iTicketRepo.EditTicket(ticket);
                    }
                    if (ticket.TutorId != null)
                    {
                        ticket.Tutor = iTutorRepo.FindTutor(ticket.TutorId);
                        //ticket.Tutor.Major = iMajorRepo.FindMajor(ticket.Tutor.MajorID); // need to add major in mock data for unit test to pass
                        return View(ticket);

                    }
                    else
                    {
                        return RedirectToAction("NoQualifiedTutors", ticket);
                    }
                }
                else
                {
                    ViewData["AllTickets"] = new SelectList(iTicketRepo.ListAllTickets(), "TicketID", "TicketID", "StudentID");
                    ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
  
                    return View(ticket);
                }
            }
            else
            {
                return RedirectToAction("NoTicketFound");
            }
        }






        //public IActionResult NewAssignQualifiedTutor(int ticketID)
        //{
        //    Ticket ticket = iTicketRepo.FindTicket(ticketID);

        //    ticket.Course = iCourseRepo






        //}





        public IActionResult UnassignTutor(int ticketID)
        {
            Ticket ticket = iTicketRepo.FindTicket(ticketID);
            ticket.TutorId = null;
            ticket.Tutor = null;

            iTicketRepo.EditTicket(ticket);
            return RedirectToAction("ListAllTickets");
        }


        // Add 20 Random Tickets - For testing purposes 

        public IActionResult AddTestTickets()
        {
            List<Ticket> ticketList = iTicketRepo.ListAllTickets();
            List<Course> courseList = iCourseRepo.ListAllCourses();
            List<Student> studentList = iStudentRepo.ListAllStudents();
            Random random = new Random();

            
            int count = 0;
            while(count < 20)
            { count++;

                int ticketCount = iTicketRepo.ListAllTickets().Count;

                // Get random Course
                Course course = courseList.OrderBy(x => random.Next()).Take(1).FirstOrDefault();

                // Get random Student
                Student student = studentList.OrderBy(x => random.Next()).Take(1).FirstOrDefault();

                // Random Rating between 3 & 5
                int rating = random.Next(4);
                rating = rating+2;

                if (random.Next(0, 100) < 40) // Assign Tutor sometimes - about 40 % or less probability 
                {
                    // Get a random Tutor from the List
                    List<Tutor> tutorList = iTutorRepo.ListAllTutors();
                    Tutor tutor = tutorList.OrderBy(x => random.Next()).Take(1).FirstOrDefault();
                    Ticket ticket = new Ticket($"Test Ticket #{count}", "Subdivision", $"{course.CourseDescription}", rating, student.Id, tutor.Id, "Open", null, null, false, course.CourseID, iCourseRepo); // First 20
                    //ticket.CourseCode = iCourseRepo.FindCourse(course.CourseID).CourseCode;
                    //ticket.Course = iCourseRepo.FindCourse(course.CourseID);

                    if (iTicketRepo.ListAllTickets().Where(t => t.TicketName == ticket.TicketName).ToList().Any())
                    {
                        ticket = new Ticket($"Test Ticket #{ticketCount+1}", "Subdivision", $"{course.CourseDescription}", rating, student.Id, tutor.Id, "Open", null, null, false, course.CourseID, iCourseRepo); // Add after 20
                        //ticket.CourseCode = iCourseRepo.FindCourse(course.CourseID).CourseCode;
                        //ticket.Course = iCourseRepo.FindCourse(course.CourseID);
                    }

                    iTicketRepo.AddTicket(ticket);
                }
                else // Dont Assign Tutor
                {
                    Ticket ticket = new Ticket($"Test Ticket #{count}", "Subdivision", $"{course.CourseDescription}", rating, student.Id, null, "Open", null, null, false, course.CourseID, iCourseRepo);
                    //ticket.CourseCode = iCourseRepo.FindCourse(course.CourseID).CourseCode;
                    //ticket.Course = iCourseRepo.FindCourse(course.CourseID);

                    if (iTicketRepo.ListAllTickets().Where(t => t.TicketName == ticket.TicketName).ToList().Any())
                    {
                        ticket = new Ticket($"Test Ticket #{ticketCount+1}", "Subdivision", $"{course.CourseDescription}", rating, student.Id, student.Id, "Open", null, null, false, course.CourseID, iCourseRepo); // Add after 20
                        //ticket.CourseCode = iCourseRepo.FindCourse(course.CourseID).CourseCode;
                        //ticket.Course = iCourseRepo.FindCourse(course.CourseID);
                    }

                    iTicketRepo.AddTicket(ticket);
                }
            }
            ticketList = iTicketRepo.ListAllTickets();
            return View(ticketList);
        }

        
        // Error Views
        public IActionResult NoQualifiedTutors(Ticket ticket) // Show when we cannot find a qualified tutor
        {
            return View(ticket);
        }

        public IActionResult NoTicketFound() // Show when there is no ticket found
        {
            ViewData["AllTickets"] = new SelectList(iTicketRepo.ListAllTickets(), "TicketID", "StudentID");
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            return View();
        }

    }
}
