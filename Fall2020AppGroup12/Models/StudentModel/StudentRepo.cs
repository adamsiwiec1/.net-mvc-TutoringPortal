using Fall2020AppGroup12.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.StudentModel
{
    public class StudentRepo : IStudentRepo
    {
        private ApplicationDbContext database;
        private IHttpContextAccessor httpContext;

        public StudentRepo(ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
            this.httpContext = contextAccessor;
        }

        // Add functions

        public string AddStudent(Student student)
        {
            database.Student.Add(student);
            database.SaveChanges();
            return student.Id;
        }

        public string FindLoggedInStudent()
        {
           return httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public Student FindStudent(string studentId)
        {
            Student student = database.Student.Find(studentId);
            return student;
        }


        public List<Student> ListAllStudents()
        {
            List<Student> students = database.Student.ToList();
            return students;
        }

    }
}
