using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.AppUserModel;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup12.Controllers
{
    public class ResponseController : Controller
    {
        private IApplicationUserRepo iAppUserRepo;
        private IDepartmentRepo iDepartmentRepo;
        private ICourseRepo iCourseRepo;
        private IDiscussionRepo iDiscussionRepo;
        private IResponseRepo iResponseRepo;
        private ICommentRepo iCommentRepo;

        public ResponseController(IDepartmentRepo departmentRepo = null, ICourseRepo courseRepo = null, IDiscussionRepo discussionRepo = null, IResponseRepo responseRepo = null, ICommentRepo commentRepo = null, IApplicationUserRepo appUserRepo = null)
        {
            this.iDepartmentRepo = departmentRepo;
            this.iDiscussionRepo = discussionRepo;
            this.iCourseRepo = courseRepo;
            this.iResponseRepo = responseRepo;
            this.iCommentRepo = commentRepo;
            this.iAppUserRepo = appUserRepo;
        }

        // Add
        [HttpGet]
        public IActionResult AddResponse()
        {
            ViewData["AllDiscussions"] = new SelectList(iDiscussionRepo.ListAllDiscussions(), "DiscussionID", "DiscussionTitle");
            return View();
        }
        
        [HttpPost]
        public IActionResult AddResponse(Response response)
        {
            if(response.UserId == null)
            {
                response.UserId = iAppUserRepo.FindLoggedInUser();
            }
            if (ModelState.IsValid)
            {
                iResponseRepo.AddResponse(response);
                return RedirectToAction("ListAllResponses");
            }
            else
            {
                return View();
            }
        }

        // Edit
        [HttpGet]
        public IActionResult EditResponse(int? responseID)
        {
            ViewData["AllResponses"] = new SelectList(iResponseRepo.ListAllResponses(), "ResponseID", "Title");
            ViewData["AllDiscussions"] = new SelectList(iDiscussionRepo.ListAllDiscussions(), "DiscussionID", "DiscussionTitle");
            Response response = iResponseRepo.FindResponse(responseID);
            return View(response);
        }

        [HttpPost]
        public IActionResult EditResponse(Response response)
        {
            if (ModelState.IsValid)
            {
                iResponseRepo.EditResponse(response);
                return RedirectToAction("ListAllResponses");
            }
            else
            {
                ViewData["AllResponses"] = new SelectList(iResponseRepo.ListAllResponses(), "ResponseID", "ResponseTitle");
                return View(response);
            }
        }

        // Delete
        public IActionResult ConfirmDeleteResponse(int? responseID)
        {
            Response response = iResponseRepo.FindResponse(responseID);
            return View(response);
        }

        public IActionResult DeleteResponse(Response response)
        {
            iResponseRepo.DeleteResponse(response);
            return RedirectToAction("ListAllResponses", "Response");
        }


        // List All
        public IActionResult ListAllResponses()
        {
            List<Response> allResponses = iResponseRepo.ListAllResponses();

            return View(allResponses);
        }

    }
}
