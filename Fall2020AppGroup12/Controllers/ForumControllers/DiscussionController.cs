using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020AppGroup12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class DiscussionController : Controller
    {

        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;

        public DiscussionController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
        }

        // Add
        [HttpGet]
        public IActionResult AddDiscussion(int? courseID = null)
        {
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");

            if (courseID != null) // Use this to Add Discussion from Empty Discussion view. User clicks 'Add discussion' and the course field is already filled. 
            {
                Course course = iCourseRepo.FindCourse(courseID);
                Discussion discussion = new Discussion();
                discussion.RequestForCourse = course;
                return View(discussion);
            }
            else
            {
                return View();
            }
        }



        [HttpPost]
        public IActionResult AddDiscussion(Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                iDiscussionRepo.AddDiscussion(discussion);
                return RedirectToAction("ListAllDiscussions", "Discussion");
            }
            else
            {
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
                ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
                ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
                return View();
            }

        }


        [HttpGet]
        public IActionResult AddDiscussionAdmin(int? courseID = null)
        {
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");

            if (courseID != null) // Use this to Add Discussion from Empty Discussion view. User clicks 'Add discussion' and the course field is already filled. 
            {
                Course course = iCourseRepo.FindCourse(courseID);
                Discussion discussion = new Discussion();
                discussion.RequestForCourse = course;
                return View(discussion);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddDiscussionAdmin(Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                iDiscussionRepo.AddDiscussion(discussion);
                return RedirectToAction("ListAllDiscussions", "Discussion");
            }
            else
            {
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
                ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
                ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
                return View();
            }

        }


        // Edit
        [HttpGet]
        public IActionResult EditDiscussion(int? discussionID)
        {
            ViewData["AllDiscussions"] = new SelectList(iDiscussionRepo.ListAllDiscussions(), "DiscussionID", "DiscussionTitle");
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
            ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
            ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
            Discussion discussion = iDiscussionRepo.FindDiscussion(discussionID);
            return View(discussion);
        }

        [HttpPost]
        public IActionResult EditDiscussion(Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                iDiscussionRepo.EditDiscussion(discussion);
                return RedirectToAction("ListAllDiscussions");
            }
            else
            {
                ViewData["AllDiscussions"] = new SelectList(iDiscussionRepo.ListAllDiscussions(), "DiscussionID", "DiscussionTitle");
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
                ViewData["AllTutors"] = new SelectList(iTutorRepo.ListAllTutors(), "Id", "FullName");
                ViewData["AllStudents"] = new SelectList(iStudentRepo.ListAllStudents(), "Id", "FullName");
                return View(discussion);
            }
        }

        // Delete 
        public IActionResult ConfirmDeleteDiscussion(int? discussionID)
        {
            Discussion discussion = iDiscussionRepo.FindDiscussion(discussionID);
            return View(discussion);
        }

        public IActionResult DeleteDiscussion(Discussion discussion)
        {
            iDiscussionRepo.DeleteDiscussion(discussion);
            return RedirectToAction("ListAllDiscussions", "Discussion");

        }

        // List All
        public IActionResult ListAllDiscussions()
        {
            List<Discussion> allDiscussions = iDiscussionRepo.ListAllDiscussions();
            return View(allDiscussions);
        }


        // Search
        public IActionResult SearchForDiscussionsByCourse(SearchForDiscussionsInCourseViewModel viewModel)
        {
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");

            List<Discussion> searchList;


            if (viewModel.UserFirstVisit != "No")
            {
                searchList = null;

            }
            else
            {
                searchList = iDiscussionRepo.ListAllDiscussions();

                if (!string.IsNullOrEmpty(viewModel.CourseID))
                {
                    searchList = searchList.Where(c => c.CourseID == int.Parse(viewModel.CourseID)).ToList();
                }
                if (viewModel.DiscussionTitle != null)
                {
                    searchList = searchList.Where(c => c.DiscussionTitle == viewModel.DiscussionTitle).ToList();

                }
                if (viewModel.DiscussionDescription != null)
                {
                    searchList = searchList.Where(c => c.DiscussionDescription == viewModel.DiscussionDescription).ToList();

                }
            }

            viewModel.ResultList = searchList;
            return View(viewModel);
        }

        public IActionResult SearchDiscussionsByDepartmentUserInput(SearchForDiscussionsInDepartmentViewModel viewModel)
        {

            ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");

            List<Discussion> searchList = new List<Discussion>();
            List<Discussion> discList;
            List<Course> courseList;
            if (viewModel.UserFirstVisit != "No")
            {
                searchList = null;

            }
            else
            {
                discList = iDiscussionRepo.ListAllDiscussions();
                courseList = iCourseRepo.ListAllCourses();

                if (!string.IsNullOrEmpty(viewModel.DepartmentID))
                {
                    // Get list of courses in dept
                    courseList = courseList.Where(c => c.DepartmentID == int.Parse(viewModel.DepartmentID)).ToList();

                    foreach (Discussion disc in discList)
                    {
                        if (courseList.Any(item => item.CourseID == disc.CourseID))
                        {
                            searchList.Add(disc);
                        }

                    }
                }
                if (!string.IsNullOrEmpty(viewModel.DiscussionTitle))
                {
                    searchList = searchList.Where(c => c.DiscussionTitle == viewModel.DiscussionTitle).ToList();

                }
                if (!string.IsNullOrEmpty(viewModel.DiscussionDescription))
                {
                    searchList = searchList.Where(c => c.DiscussionDescription == viewModel.DiscussionDescription).ToList();

                }
            }

            viewModel.ResultList = searchList;
            return View(viewModel);
        }

        //Lists all Responses and Comments for each Discussion
        public IActionResult SearchDetailedDiscussionsByDepartmentUserInput(SearchForDetailedDiscussionsInDepartmentViewModel viewModel)
        {

            ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");

            List<Discussion> discusssionSearchList = new List<Discussion>();
            List<Response> responseSearchList = new List<Response>();
            List<Comment> commentSearchList = new List<Comment>();
            List<Discussion> discList;
            List<Course> courseList;
            List<Response> responseList;
            List<Comment> commentList;

            if (viewModel.UserFirstVisit != "No")
            {
                discusssionSearchList = null;
                responseSearchList = null;
                commentSearchList = null;
            }
            else
            {
                courseList = iCourseRepo.ListAllCourses();
                discList = iDiscussionRepo.ListAllDiscussions();
                responseList = iResponseRepo.ListAllResponses();
                commentList = iCommentRepo.ListAllComments();

                if (!string.IsNullOrEmpty(viewModel.DepartmentID))
                {
                    // Get list of courses in dept
                    courseList = courseList.Where(c => c.DepartmentID == int.Parse(viewModel.DepartmentID)).ToList();

                    foreach (Discussion disc in discList)
                    {
                        if (courseList.Any(item => item.CourseID == disc.CourseID))
                        {
                            discusssionSearchList.Add(disc);
                        }

                    }
                }
                if (!string.IsNullOrEmpty(viewModel.DiscussionTitle))
                {
                    discusssionSearchList = discusssionSearchList.Where(c => c.DiscussionTitle == viewModel.DiscussionTitle).ToList();

                }
                if (!string.IsNullOrEmpty(viewModel.DiscussionDescription))
                {
                    discusssionSearchList = discusssionSearchList.Where(c => c.DiscussionDescription == viewModel.DiscussionDescription).ToList();

                }
                if (!string.IsNullOrEmpty(viewModel.DepartmentID))
                {

                    foreach (Discussion disc in discList)
                    {
                        responseList = responseList.Where(r => r.DiscussionID == disc.DiscussionID).ToList();

                        if (responseList.Any())
                        {
                            foreach (Response response in responseList) //Get all responses in Dept
                            {
                                responseSearchList.Add(response);

                                if (response.CommentsInResponse.Any())
                                {
                                    foreach (Comment comment in response.CommentsInResponse) //For each response in this Dept, add it's comments to our searchList.
                                    {
                                        commentSearchList.Add(comment);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            viewModel.DiscussionResultList = discusssionSearchList;
            viewModel.ResponseResultList = responseSearchList;
            viewModel.CommentResultList = commentSearchList;
            return View(viewModel);
        }
    }

}


