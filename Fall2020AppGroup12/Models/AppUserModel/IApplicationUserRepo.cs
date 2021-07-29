using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.AppUserModel
{
    public interface IApplicationUserRepo
    {
        string FindLoggedInUser();

        ApplicationUser FindApplicationUser(string userId);

        List<ApplicationUser> ListAllUsers();
    }
}
