using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Controllers
{
    public class TutorCourseController : Controller
    {

        private ITutorRepo iTutorRepo;
        private IStudentRepo iStudentRepo;
        private ITutorCourseRepo iTutorCourseRepo;

        public TutorCourseController(ITutorCourseRepo tutorCourseRepo, ITutorRepo tutorRepo = null, IStudentRepo studentRepo = null)
        {
            this.iTutorCourseRepo = tutorCourseRepo;
            this.iTutorRepo = tutorRepo;
            this.iStudentRepo = studentRepo;

        }


        public IActionResult ListAllTutorCourses()
        {
            List<TutorCourse> allTutorCourses = iTutorCourseRepo.ListAllTutorCourses();

            return View(allTutorCourses);
        }


        //[HttpGet]
        //public IActionResult AddQualifiedTutor()
        //{




        //    return View(tutorCourse);
        //}


    }
}
