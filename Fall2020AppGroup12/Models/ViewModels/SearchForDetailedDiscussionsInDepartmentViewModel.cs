using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class SearchForDetailedDiscussionsInDepartmentViewModel
    {

        public string DepartmentID { get; set; }

        //We need course ID to get from the Discussion table to the Department table 
        public string CourseID { get; set; }

        public string DiscussionTitle { get; set; }

        public string DiscussionDescription { get; set; }

        public string UserFirstVisit { get; set; }

        public string ResponseID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string CommentID { get; set; }

        public string CBody { get; set; }


        //Properties for Search Results
        public List<Discussion> DiscussionResultList { get; set; }
        public List<Response> ResponseResultList { get; set; }
        public List<Comment> CommentResultList { get; set; }


        public SearchForDetailedDiscussionsInDepartmentViewModel()
        {

        }

    }
}
