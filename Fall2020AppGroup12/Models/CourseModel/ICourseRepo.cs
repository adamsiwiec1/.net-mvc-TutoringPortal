using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CourseModel
{
    public interface ICourseRepo
    {

        List<Course> ListAllCourses();

        void AddCourse(Course course);
        void DeleteCourse(Course course);
        void EditCourse(Course course);
        Course FindCourse(int? courseID);
        //List<Tutor> ListAllQualifiedTutors(int courseID);
    }
}
