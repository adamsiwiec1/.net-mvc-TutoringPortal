using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CourseModel
{
    public class CourseRepo : ICourseRepo
    {
        private ApplicationDbContext database;

        public CourseRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add
        public void AddCourse(Course course)
        {
            database.Course.Add(course);
            database.SaveChanges();
        }

        //Edit
        public void EditCourse(Course course)
        {
            database.Course.Update(course);
            database.SaveChanges();
        }

        //Delete
        public void DeleteCourse(Course course)
        {
            // Check if there is any discussions in course  - I think i had to make this because Cascade vs Restrict? idk
            if (course.DiscussionsInCourse != null)
            {
                // Remove all discussions in course first prior to removing the course - need to set a warning message for this 
                foreach (Discussion discussion in course.DiscussionsInCourse)
                {
                    database.Discussion.Remove(discussion);
                }
            }

            database.Course.Remove(course);
            database.SaveChanges();
        }

        // List All
        public List<Course> ListAllCourses()
        {
            List<Course> courses = database.Course.ToList();
            return courses;
        }

        // Search
        public Course FindCourse(int? courseID)
        {
            return database.Course.Find(courseID); 
        }

        //public List<Tutor> ListAllQualifiedTutors(int courseID)
        //{
        //    List<Tutor> qualifiedTutors = new List<Tutor>();

        //    List<Tutor> tutors = database.Tutor.ToList();

        //    foreach(Tutor tutor in tutors) // For every tutor
        //    {
        //        foreach(TutorCourse tutorCourse in tutor.QualifiedCourses) // Check if any of their qualified courses match the requested Course
        //        {
        //            if(tutorCourse.CourseID == courseID) // If so, add that tutor to the list
        //            {
        //                qualifiedTutors.Add(tutor);
        //            }
        //        }
        //    }

        //    return qualifiedTutors;
        //}
    }
}
