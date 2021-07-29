using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class MajorController : Controller
    {
        private IMajorRepo iMajorRepo;
        private IDepartmentRepo iDepartmentRepo;
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;

        public MajorController(IMajorRepo majorRepo, IDepartmentRepo departmentRepo = null, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null)
        {
            this.iMajorRepo = majorRepo;
            this.iDepartmentRepo = departmentRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
        }

        [HttpGet]
        public IActionResult AddMajor()
        {
            ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                iMajorRepo.AddMajor(major);
                return RedirectToAction("ListAllMajors");
            }
            else
            {
                ViewData["AllDepartments"] = new SelectList(iDepartmentRepo.ListAllDepartments(), "DepartmentID", "DepartmentName");
                return View(major);
            }
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

        [HttpGet]
        public IActionResult EditMajor(int? majorID)
        {
            ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");

            Major major = iMajorRepo.FindMajor(majorID);
            return View(major);
        }

        [HttpPost]
        public IActionResult EditMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                iMajorRepo.EditMajor(major);
                return RedirectToAction("ListAllMajors");
            }
            else
            {
                ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");
                return View(major);
            }
        }

        public IActionResult ConfirmDeleteMajor(int? majorID)
        { 
            Major major = iMajorRepo.FindMajor(majorID);
            return View(major);

        }

        public IActionResult DeleteMajor(Major major)
        {
            iMajorRepo.DeleteMajor(major);
            return RedirectToAction("ListAllMajors");
        }



    }
}
