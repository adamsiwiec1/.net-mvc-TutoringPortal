using Fall2020AppGroup12.Models.DiscussionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class SearchForDiscussionsInCourseViewModel
    {

        public string CourseID { get; set; }

        public string DiscussionTitle { get; set; }

        public string DiscussionDescription { get; set; }

        public string UserFirstVisit { get; set; }

        //Property for Search Result
        public List<Discussion> ResultList { get; set; }

        public SearchForDiscussionsInCourseViewModel()
        {

        }


    }
}
