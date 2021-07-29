using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TutorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class ListForumViewModel
    {
        public List<Department> Departments { get; set; }

        public List<Course> Courses { get; set; }

        public List<Discussion> Discussions { get; set; }

        public List<Response> Responses { get; set; }

        public List<Comment> Comments { get; set; }

        public ListForumViewModel(List<Department> departments, List<Course> courses, List<Discussion> discussions, List<Response> responses, List<Comment> comments)
        {
            Departments = departments;
            Courses = courses;
            Discussions = discussions;
            Responses = responses;
            Comments = comments;
        }

        public ListForumViewModel()
        {

        }
    }
}
