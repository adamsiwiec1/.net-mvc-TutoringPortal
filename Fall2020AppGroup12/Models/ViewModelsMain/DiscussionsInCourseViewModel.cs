using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ViewModels
{
    public class DiscussionsInCourseViewModel
    {

        public List<Discussion> Discussions { get; set; }

        public Course Course { get; set; }

        public DiscussionsInCourseViewModel()
        {
            Discussions = new List<Discussion>();
        }

    }
}
