using System;
using System.Collections.Generic;
using System.Text;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Fall2020AppGroup12.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {


        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Response> Response { get; set; }

        public DbSet<Discussion> Discussion { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Student> Student { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TutorCourse> TutorCourse { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
