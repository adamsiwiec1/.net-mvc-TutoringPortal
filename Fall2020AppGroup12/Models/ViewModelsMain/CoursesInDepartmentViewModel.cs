using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class CoursesInDepartmentViewModel
    {

        public List<Course> Courses { get; set; }

        public Department Department { get; set; }


        public CoursesInDepartmentViewModel()
        {
            Courses = new List<Course>();
        }

    }
}
