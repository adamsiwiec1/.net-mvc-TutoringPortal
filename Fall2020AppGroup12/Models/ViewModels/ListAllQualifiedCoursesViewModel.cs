using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class ListAllQualifiedCoursesViewModel
    {
        public string TutorID { get; set; }

        public List<TutorCourse> ResultCourseList { get; set; }

    }
}
