using Fall2020AppGroup12.Models.AppUserModel;
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
using Fall2020AppGroup12.Models.ViewModelsMain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fall2020AppGroup12.Controllers
{
    public class ForumController : Controller
    {
        private IApplicationUserRepo iAppUserRepo;
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        //private IMajorRepo iMajorRepo;
        //private ITutorRepo iTutorRepo;
        //private IStudentRepo iStudentRepo;
        //private ITicketRepo iTicketRepo;
        //private ITutorCourseRepo iTutorCourseRepo;

        public ForumController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null, IMajorRepo majorRepo = null, ITicketRepo ticketRepo = null, ITutorCourseRepo tutorCourseRepo = null, IApplicationUserRepo appUserRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
            //this.iTutorRepo = tutorRepo;
            //this.iStudentRepo = studentRepo;
            //this.iMajorRepo = majorRepo;
            //this.iTicketRepo = ticketRepo;
            //this.iTutorCourseRepo = tutorCourseRepo;
            this.iAppUserRepo = appUserRepo;
        }

        // Complex work flow - Forum Access and navigation

        public IActionResult ForumAccess()
        {
            // Store user session for 30 min upon accessing forum 
            string userId = iAppUserRepo.FindLoggedInUser();
            var user = iAppUserRepo.FindApplicationUser(userId);
            if (user != null)
            {
                HttpContext.Session.SetString(user.FullName, userId);

                var departments = iDepartmentRepo.ListAllDepartments();

                return View(departments);
            }
            else
            {
                return RedirectToAction("ForumAccessErrorView1", "ErrorView");
            }
        }


        public IActionResult CoursesInDepartment(int departmentID)
        {
            CoursesInDepartmentViewModel viewModel = new CoursesInDepartmentViewModel();
            List<Course> courses = iCourseRepo.ListAllCourses();
            viewModel.Department = iDepartmentRepo.FindDepartment(departmentID);

            foreach (Course course in courses)
            {
                if (course.DepartmentID == departmentID)
                {
                    viewModel.Courses.Add(course);
                }
            }
            return View(viewModel);
        }

        public IActionResult DiscussionsInDepartment(int departmentID)
        {
            List<Discussion> discussionResultList = new List<Discussion>();
            List<Discussion> discussions = iDiscussionRepo.ListAllDiscussions();

            // Get course for each discussion
            foreach (Discussion discussion in discussions)
            {
                discussion.RequestForCourse = iCourseRepo.FindCourse(discussion.CourseID);

                // Get Department
                discussion.RequestForCourse.RequestForDepartment = iDepartmentRepo.FindDepartment(departmentID);
            }

            foreach (Discussion discussion in discussions)
            {
                if (discussion.RequestForCourse.DepartmentID == departmentID)
                {
                    discussionResultList.Add(discussion);
                }
            }
            return View(discussionResultList);
        }

        public IActionResult DiscussionsInCourse(int courseID) // Update 4/19
        {
            DiscussionsInCourseViewModel viewModel = new DiscussionsInCourseViewModel();
            List<Discussion> allDiscussions = new List<Discussion>();

            // Retreive course object from courseID
            viewModel.Course = iCourseRepo.FindCourse(courseID);

            // Get All Discussions Relevant to this course
            viewModel.Discussions = iDiscussionRepo.ListAllDiscussions().Where(d => d.CourseID == courseID).ToList();

            // Populate Course Object for each Discussion
            foreach (Discussion discussion in viewModel.Discussions)
            {
                discussion.RequestForCourse = iCourseRepo.FindCourse(discussion.CourseID);
            }

            return View(viewModel);
        }

        public IActionResult AccessDiscussion(int discussionID)
        { 

            AccessDiscussionViewModel viewModel = new AccessDiscussionViewModel();
            viewModel.Discussion = iDiscussionRepo.FindDiscussion(discussionID);

            // Get Responses in Discussion
            viewModel.Discussion.ResponsesInDiscussion = iResponseRepo.ListAllResponses().Where(r => r.DiscussionID == discussionID).ToList();

            // Get Comments in Response
            foreach (Response response in viewModel.Discussion.ResponsesInDiscussion)
            {
                response.CommentsInResponse = iCommentRepo.ListAllComments().Where(c => c.ResponseID == response.ResponseID).ToList();

                response.ApplicationUser = iAppUserRepo.FindApplicationUser(response.UserId);

                //foreach(Comment comment in response.CommentsInResponse)
                //{
                //    comment
                //}

            }

            return View(viewModel);
        }

        // End of Complex Work Flow - Forum access and navigation

        // Forum Methods 

        //User Add Response to Discussion

        [HttpPost]
        public IActionResult UserAddResponse(Response userReponse)
        {
            if (ModelState.IsValid){ }

            string loggedInUser = iAppUserRepo.FindLoggedInUser();
            userReponse.UserId = loggedInUser;
            //userReponse.DiscussionID = discussionID;

            try
            {
                iResponseRepo.AddResponse(userReponse);
                return RedirectToAction("AccessDiscussion", "Forum", userReponse.UserId);//userReponse.DiscussionID);
            }
            catch
            {
                return RedirectToAction("AccessDiscussion", "Forum", userReponse.UserId);// userReponse.DiscussionID); //and display appropriate error message
            }
        }

    }
}
