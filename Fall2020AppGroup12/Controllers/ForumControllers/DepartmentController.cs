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
    public class DepartmentController : Controller
    {
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null)
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
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                iDepartmentRepo.AddDepartment(department);
                return RedirectToAction("ListAllDepartments");
            }
            else
            {
                return View();
            }
        }


        // Edit

        [HttpGet]
        public IActionResult EditDepartment(int? deptID)
        {
            ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");

            Department department = iDepartmentRepo.FindDepartment(deptID);
            return View(department);
        }

        [HttpPost]
        public IActionResult EditDepartment(Department department)
        {
            if(ModelState.IsValid)
            {
                iDepartmentRepo.EditDepartment(department);
                return RedirectToAction("ListAllDepartments");
            }
            else
            {
                ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");
                return View(department);
            }
        }

        // Delete

        public IActionResult ConfirmDeleteDepartment(int? deptID)
        {
            Department department = iDepartmentRepo.FindDepartment(deptID);
            return View(department);
        }

        public IActionResult DeleteDepartment(Department department)
        {
            iDepartmentRepo.DeleteDepartment(department);
            return RedirectToAction("ListAllDepartments");
        }

        // List All

        public IActionResult ListAllDepartments()
        {
            List<Department> allDepartments = iDepartmentRepo.ListAllDepartments();

            return View(allDepartments);
        }
    }
}
