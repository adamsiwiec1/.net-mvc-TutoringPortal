using Fall2020AppGroup12.Models.AppUserModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Controllers
{
    public class AspNetUserController : Controller
    {

        private IApplicationUserRepo iApplicationUserRepo;

        public AspNetUserController(IApplicationUserRepo applicationUserRepo)
        {
            this.iApplicationUserRepo = applicationUserRepo;
        }
        

        // Student view method handles all redirect - students are the most freq user so they get view first
        public IActionResult StudentProfile(string userId)
        {
            if(User.IsInRole("Student"))
            {

                return View(); 
            }
            else if(User.IsInRole("Administrator"))
            {
                return View("AdminProfile", userId);
            }
            else if(User.IsInRole("Tutor"))
            {
                return View("TutorProfile", userId);
            }
            else
            {
                return RedirectToAction("ProfileErrorView", "ErrorView");
            }
           
        }

        public IActionResult AdminProfile(string userId)
        {
            ApplicationUser appUser = iApplicationUserRepo.FindApplicationUser(userId);

            return View(appUser);
        }

        public IActionResult TutorProfile(string userId)
        {

            return View();
        }

    }
}
