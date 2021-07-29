using Fall2020AppGroup12.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DepartmentModel
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Name cannot be left blank.")]
        public string DepartmentName { get; set;}

        [Required(ErrorMessage = "Department Description cannot be left blank.")]
        public string DepartmentDescription { get; set; }

        public List<Course> CoursesInDepartment { get; set; }

        public Department(string deptname, string deptdesc)
        {
            this.DepartmentName = deptname;
            this.DepartmentDescription = deptdesc;
            this.CoursesInDepartment = new List<Course>();
        }

        public Department() { }

    }
}
