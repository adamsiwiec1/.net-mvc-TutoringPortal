using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CommentModel
{
    public class Comment
    {
        // Test
        [Key]
        public int CommentID { get; set; }

        [Required(ErrorMessage = "Your comment must contain at least one character.")]
        public string Body { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int ResponseID { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("ResponseID")]
        public Response Response { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public Comment(string cbody, int rid, string userId)
        {
            this.Body = cbody;
            this.DateTime = DateTime.Now;
            this.ResponseID = rid;
            this.UserId = userId;
        }

        public Comment() { }

    }
}
