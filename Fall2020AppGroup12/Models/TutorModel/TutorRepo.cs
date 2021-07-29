using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.TutorModel
{
    public class TutorRepo : ITutorRepo
    {

        private ApplicationDbContext database;

        public TutorRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add functions

        public string AddTutor(Tutor tutor)
        {
            database.Tutor.Add(tutor);
            database.SaveChanges();
            return tutor.Id;
        }


        public Tutor FindTutor(string tutorId)
        {
            Tutor tutor = database.Tutor.Find(tutorId);
            return tutor;
        }

        public List<Tutor> ListAllTutors()
        {
            List<Tutor> tutors = database.Tutor.ToList();
            
            return tutors;
        }

        public List<Course> ListAllQualifiedCourses(string tutorID)
        {
            List<Course> qualifiedCourses = new List<Course>();
            List<Course> courses = database.Course.ToList();
            foreach (Course course in courses)
            {
                foreach (TutorCourse tutorCourse in course.QualifiedTutors)
                {
                    if (tutorCourse.TutorID == tutorID)
                    {
                        qualifiedCourses.Add(course);

                    }
                }
            }

            return qualifiedCourses;
        }

    }
}
