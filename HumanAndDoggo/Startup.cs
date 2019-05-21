using System;
using System.Collections.Generic;
using System.Linq;
using HumanAndDoggo.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HumanAndDoggo.Startup))]

namespace HumanAndDoggo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            //app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            //createRolesAndUsers();
        }
        //private void createRolesAndUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "human@doggo.kennel";
                string userPWD = "humananddoggo";

        //        var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Email, "Admin");
                }

        //    }
        //}
    }
}
