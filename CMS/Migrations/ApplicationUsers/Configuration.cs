namespace CMS.Migrations.ApplicationUsers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationUsers";
        }

        protected override void Seed(CMS.Models.ApplicationDbContext context)
        {
            var manager =
        new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Admin" });
            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S12345678@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S12345678@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("Ss1234567$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
            ApplicationUser admin = manager.FindByEmail("S12345678@mail.itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }
        }
    }
}
