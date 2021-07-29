using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CourseModel
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Code Code cannot be left blank.")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course Description cannot be left blank.")]
        public string CourseDescription { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department RequestForDepartment { get; set; }

        public List<Discussion> DiscussionsInCourse { get; set; }

        public List<TutorCourse> QualifiedTutors { get; set; }

        public Course(string courseCode, string courseDesc, int deptid)
        {
            this.CourseCode = courseCode;
            this.CourseDescription = courseDesc;
            this.DepartmentID = deptid;
            this.DiscussionsInCourse = new List<Discussion>();
            this.QualifiedTutors = new List<TutorCourse>();
        }

        public Course() { }

    }
}
