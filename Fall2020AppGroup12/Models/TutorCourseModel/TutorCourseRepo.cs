using Fall2020AppGroup12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TutorCourseModel
{
    public class TutorCourseRepo : ITutorCourseRepo
    {


        private ApplicationDbContext database;

        public TutorCourseRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public List<TutorCourse> ListAllTutorCourses()
        {
            List<TutorCourse> tutorCourses = database.TutorCourse.ToList();

            return tutorCourses;
        }

        public List<TutorCourse> ListAllTutorCoursesForTutor(string tutorID)
        {
            List<TutorCourse> tutors = database.TutorCourse.ToList().Where(t => t.TutorID == tutorID).ToList();

            return tutors;
        }


    }
}
