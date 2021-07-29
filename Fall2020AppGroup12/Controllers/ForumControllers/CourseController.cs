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
    public class CourseController : Controller
    {
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;

        public CourseController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null)
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
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                iCourseRepo.AddCourse(course);
                return RedirectToAction("ListAllCourses");
            }
            else
            {
                return View();
            }
        }

        // Edit

        [HttpGet]
        public IActionResult EditCourse(int? courseID)
        {
            ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");
            ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
            Course course = iCourseRepo.FindCourse(courseID);
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                iCourseRepo.EditCourse(course);
                return RedirectToAction("ListAllCourses");
            }
            else
            {
                ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");
                ViewData["AllCourses"] = new SelectList(iCourseRepo.ListAllCourses(), "CourseID", "CourseCode");
                return View(course);
            }
        }

        // Delete

        public IActionResult ConfirmDeleteCourse(int? courseID)
        {
            Course course = iCourseRepo.FindCourse(courseID);
            return View(course);
        }

        public IActionResult DeleteCourse(Course course)
        {
            iCourseRepo.DeleteCourse(course);
            return RedirectToAction("ListAllCourses");
        }

        // List All

        public IActionResult ListAllCourses()
        {
            List<Course> allCourses = iCourseRepo.ListAllCourses();

            return View(allCourses);
        }

        //public IActionResult ListAllQualifiedTutors(int courseID)
        //{
        //    List<Tutor> qualifiedTutors = iCourseRepo.ListAllQualifiedTutors(courseID);

        //    return View(qualifiedTutors);
        //}
    }
}
