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
using Fall2020AppGroup12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Controllers
{
    public class EtcController : Controller
    {
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        private IMajorRepo iMajorRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;
        private ITicketRepo iTicketRepo;
        private ITutorCourseRepo iTutorCourseRepo;


        public EtcController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null, IMajorRepo majorRepo = null, ITicketRepo ticketRepo = null, ITutorCourseRepo tutorCourseRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
            this.iMajorRepo = majorRepo;
            this.iTicketRepo = ticketRepo;
            this.iTutorCourseRepo = tutorCourseRepo;
        }

        public IActionResult ListAllUsers(ListAllUsersViewModel viewModel)
        {
            List<Tutor> allTutors = iTutorRepo.ListAllTutors();
            List<Tutor> tutorResultList = new List<Tutor>();

            List<Student> allStudents = iStudentRepo.ListAllStudents();
            List<Student> studentResultList = new List<Student>();

            // Get majors
            foreach (Tutor eachTutor in allTutors)
            {
                eachTutor.Major = iMajorRepo.ListAllMajors().Where(m => m.MajorID == eachTutor.MajorID).FirstOrDefault();
                tutorResultList.Add(eachTutor);
            }
            foreach (Student eachStudent in allStudents)
            {
                eachStudent.Major = iMajorRepo.ListAllMajors().Where(m => m.MajorID == eachStudent.MajorID).FirstOrDefault();
                studentResultList.Add(eachStudent);
            }

            viewModel.TutorResultList = tutorResultList;
            viewModel.StudentResultList = studentResultList;

            return View(viewModel);
        }


        public IActionResult ListDatabase(ListDatabaseViewModel viewModel)
        {

            viewModel.Departments = iDepartmentRepo.ListAllDepartments();
            viewModel.Courses = iCourseRepo.ListAllCourses();
            viewModel.Discussions = iDiscussionRepo.ListAllDiscussions();
            viewModel.Responses = iResponseRepo.ListAllResponses();
            viewModel.Comments = iCommentRepo.ListAllComments();
            viewModel.Majors = iMajorRepo.ListAllMajors();
            viewModel.Students = iStudentRepo.ListAllStudents();
            viewModel.Tutors = iTutorRepo.ListAllTutors();
            viewModel.AllTickets = iTicketRepo.ListAllTickets();
            viewModel.OpenTickets = iTicketRepo.ListAllOpenTickets();
            viewModel.InProgressTickets = iTicketRepo.ListAllInProgressTickets();
            viewModel.ClosedTickets = iTicketRepo.ListAllClosedTickets();
            viewModel.TutorCourses = iTutorCourseRepo.ListAllTutorCourses();

            return View(viewModel);
        }


        public IActionResult RequestForQualifiedTutor(int ticketID)
        {
            Ticket ticket = iTicketRepo.FindTicket(ticketID);

            return View(ticket);
        }

    }
}

