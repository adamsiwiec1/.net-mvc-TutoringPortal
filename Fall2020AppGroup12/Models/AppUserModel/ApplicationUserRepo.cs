using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.StudentModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.AppUserModel
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {

        private ApplicationDbContext database;
        private IHttpContextAccessor httpContext;

        public ApplicationUserRepo(ApplicationDbContext applicationDbContext, IHttpContextAccessor contextAccesor)
        {
            this.database = applicationDbContext;
            this.httpContext = contextAccesor;
        }

        public string FindLoggedInUser()
        {
            return httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public ApplicationUser FindApplicationUser(string userId)
        {
            ApplicationUser applicationUser = database.ApplicationUser.Find(userId);

            return applicationUser;
        }

        public Student FindTestStudentOne()
        {
            Student testStudentOne = database.Student.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();

            return testStudentOne;
        }
        public Student FindTestStudentTwo()
        {
            Student testStudentTwo = database.Student.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();

            return testStudentTwo;
        }


        public List<ApplicationUser> ListAllUsers()
        {
            return database.ApplicationUser.ToList();
        }
    }
}
