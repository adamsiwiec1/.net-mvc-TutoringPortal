using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TutorCourseModel
{
    public class TutorCourse
    {
        [Key]
        public int TutorCourseID { get; set; }

        public string TutorID { get; set; } //Dont want to track the start/end date. Will just delete from list of tutors courses

        public int CourseID { get; set; }

        [ForeignKey("TutorID")]
        public Tutor QualifiedTutor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }


        public TutorCourse(string tutorId, int courseID)
        {
            TutorID = tutorId;
            CourseID = courseID;
        }

        public TutorCourse()
        {

        }
    }
}
