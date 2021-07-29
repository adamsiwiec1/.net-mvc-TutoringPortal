using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DiscussionModel
{
    public class Discussion
    {
        [Key]
        public int DiscussionID { get; set; }

        [Required(ErrorMessage = "Discussion Title cannot be left blank.")]
        public string DiscussionTitle { get; set; }

        [Required(ErrorMessage = "Discussion Description cannot be left blank.")]
        public string DiscussionDescription { get; set; }

        [Required(ErrorMessage = "You need to add a discussion datetime.")]
        public DateTime DiscussionDateCreated { get; set; }

        [Required(ErrorMessage = "You must select a course for the discussion.")]
        public int CourseID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        [ForeignKey("CourseID")]
        public Course RequestForCourse { get; set; }

        [ForeignKey("ApplicationUserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public List<Response> ResponsesInDiscussion { get; set; }


        public Discussion(string discTitle, string discDesc, DateTime discCreated, int courseid, string applicationUserid)
        {
            this.DiscussionTitle = discTitle;
            this.DiscussionDescription = discDesc;
            this.DiscussionDateCreated = discCreated;
            this.CourseID = courseid;
            this.ApplicationUserID = applicationUserid;
            this.ResponsesInDiscussion = new List<Response>();
        }

        public Discussion() { }


    }
}
