using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class CommentController : Controller
    {
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;

        //test change

        public CommentController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
        }

        // Add
        [HttpGet]
        public IActionResult AddComment()
        {
            ViewData["AllResponses"] = new SelectList(iResponseRepo.ListAllResponses(), "ResponseID", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                iCommentRepo.AddComment(comment);
                return RedirectToAction("ListAllComments");
            }
            else
            {
                return View();
            }
        }

        // Edit
        [HttpGet]
        public IActionResult EditComment(int? commentID)
        {
            ViewData["AllComments"] = new SelectList(iCommentRepo.ListAllComments(), "CommentID", "Body");
            ViewData["AllResponses"] = new SelectList(iResponseRepo.ListAllResponses(), "ResponseID", "Title");
            Comment comment = iCommentRepo.FindComment(commentID);
            return View(comment);
        }

        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                iCommentRepo.EditComment(comment);
                return RedirectToAction("ListAllComments");
            }
            else
            {
                ViewData["AllComments"] = new SelectList(iCommentRepo.ListAllComments(), "CommentID", "Body");
                return View(comment);
            }
        }

        // Delete
        public IActionResult ConfirmDeleteComment(int? commentID)
        {
            Comment comment = iCommentRepo.FindComment(commentID);
            return View(comment);
        }

        public IActionResult DeleteComment(Comment comment)
        {
            iCommentRepo.DeleteComment(comment);
            return RedirectToAction("ListAllComments", "Comment");
        }

        // List All
        public IActionResult ListAllComments()
        {
            List<Comment> allComments = iCommentRepo.ListAllComments();

            return View(allComments);
        }
    }
}
