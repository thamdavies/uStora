namespace uStora.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<uStoraDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(uStoraDbContext context)
        {
            CreateUser(context);
        }

        private void CreateUser(uStoraDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new uStoraDbContext()));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new uStoraDbContext()));

                var user = new ApplicationUser()
                {
                    UserName = "dvbtham",
                    Email = "dvbtham@gmail.com",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = "Th�m David",
                    Address = "Gia Lai",
                    PhoneNumber = "01652130546"
                };

                manager.Create(user, "123123$");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("dvbtham@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }
        }
    }
}