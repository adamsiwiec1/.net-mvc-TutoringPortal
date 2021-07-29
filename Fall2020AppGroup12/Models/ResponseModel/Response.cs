using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.ResponseModel
{
    public class Response
    {

        [Key]
        public int ResponseID { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Body field is required.")]
        public string Body { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int DiscussionID { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("DiscussionID")]
        public Discussion Discussion { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public List<Comment> CommentsInResponse { get; set; }

        public Response(string Title, string Body, int discussionid, string userId)
        {
            this.Title = Title;
            this.Body = Body;
            this.DateTime = DateTime.Now;
            this.DiscussionID = discussionid;
            this.UserId = userId;
            this.CommentsInResponse = new List<Comment>();
        }

        public Response() { }



    }
}
