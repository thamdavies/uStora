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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(uStoraDbContext context)
        {
            CreateUser(context);
            BrandDefault(context);
            CreateContactDetail(context);
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
                    Gender = "Nam",
                    FullName = "Thâm David",
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

        private void BrandDefault(uStoraDbContext context)
        {
            if(context.Brands.Count() == 0)
            {
                var brand = new Brand()
                {
                    Name = "Không xác định",
                    Alias = "khong-xac-dinh",
                    CreatedBy = "system",
                    Status = true
                };
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(uStoraDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new ContactDetail()
                    {
                        Name = "Shop online - uStora",
                        Address = "472 Núi Thành",
                        Phone = "016 5213 0546",
                        Email = "dvbtham@gmail.com",
                        Lat = 16.034562,
                        Lng = 108.222603,
                        Website = "http://ustora.com.vn",
                        Description = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch
                {

                }
            }
        }
    }
}