using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.MajorModel
{
    public class Major
    {
        [Key]
        public int MajorID { get; set; }
        [Required]
        public string MajorName { get; set; }

        [Required]
        public string MajorAckronym { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public List<Student> StudentsInMajor { get; set; }

        public List<Tutor> TutorsInMajor { get; set; }    

        public Major(string majorName, string majorAckronym, int departmentId)
        {
            this.MajorName = majorName;
            this.MajorAckronym = majorAckronym;
            this.DepartmentID = departmentId;
            this.StudentsInMajor = new List<Student>();
            this.TutorsInMajor = new List<Tutor>();
        }
        public Major() { }

    }
}
