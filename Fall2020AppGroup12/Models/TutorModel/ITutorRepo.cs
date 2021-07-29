using Fall2020AppGroup12.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TutorModel
{
    public interface ITutorRepo
    {
        List<Tutor> ListAllTutors();

        Tutor FindTutor(string tutorId);

        string AddTutor(Tutor tutor);
        List<Course> ListAllQualifiedCourses(string tutorID);
    }
}
