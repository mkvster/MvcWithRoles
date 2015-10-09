using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using sys_data = System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWithRoles.Core.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //this.Database.SetInitializer<ApplicationDbContext>(new ApplicationCreateDb());
        }

        static ApplicationDbContext()
        {
            Debug.WriteLine("X");
            // Seed the database
            sys_data.Database.SetInitializer<ApplicationDbContext>(new ApplicationCreateDb());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Here you can put FluentAPI code or add configuration map's
        }
    }
}
