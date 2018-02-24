using meet_up.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace meet_up.Extensions
{
    public static class UserNameExtension
    {
        public static string GetUserFirstName(this IIdentity identity)
        {
            var db = ApplicationDbContext.Create();
            var users = db.Users.FirstOrDefault(u => u.firstName == identity.Name);

            return users != null ? users.firstName : String.Empty;
        }

        public static async Task GetUsers(this List<UserViewModel> users)
        {
            var db = ApplicationDbContext.Create();

            users.AddRange(await (from u in db.Users
                                  select
               new UserViewModel
               {
                   Id = u.Id,
                   FirstName = u.firstName,
                   LastName = u.lastName,
                   Email = u.Email

               }).OrderBy(o => o.Email).ToListAsync());



        }
    }
}
