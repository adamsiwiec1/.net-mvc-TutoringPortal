using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class ListAllUsersViewModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Major { get; set; }

        public string GraduationDate { get; set; }

        public List<Tutor> TutorResultList { get; set; }

        public List<Student> StudentResultList { get; set; }

        public ListAllUsersViewModel() { }
    }
}
