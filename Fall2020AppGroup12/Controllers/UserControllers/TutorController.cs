using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class TutorController : Controller
    {
        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;
        private ITutorCourseRepo iTutorCourseRepo;
        private IMajorRepo iMajorRepo;


        public TutorController(ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null, ITutorCourseRepo tutorCourseRepo = null, IMajorRepo majorRepo = null)
        {
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;
            this.iTutorCourseRepo = tutorCourseRepo;
            this.iMajorRepo = majorRepo;
        }

        [HttpGet]
        public IActionResult AddTutor()
        {

            ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");
            return View();
        }

        [HttpPost]
        public IActionResult AddTutor(Tutor tutor)
        {
            if (ModelState.IsValid)
            {

                string Id = iTutorRepo.AddTutor(tutor);
                return RedirectToAction("ListAllTutors");
            }
            else
            {
                ViewData["AllMajors"] = new SelectList(iMajorRepo.ListAllMajors(), "MajorID", "MajorName");
                return View();
            }
        }


        public IActionResult ListAllTutors()
        {
            List<Tutor> allTutors = iTutorRepo.ListAllTutors();

            foreach(Tutor tutor in allTutors)
            {
                tutor.Major = iMajorRepo.FindMajor(tutor.MajorID);
            }

            return View(allTutors);
        }

       

        public IActionResult ListAllQualifiedCourses(string tutorID)
        {
            List<Course> qualifiedCourses = iTutorRepo.ListAllQualifiedCourses(tutorID);

            return View(qualifiedCourses);
        }

    }
}
