using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MvcWithRoles.Core.Domain
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    public interface IApplicationUserStore : IUserStore<ApplicationUser, int>
    {

    }

    public class ApplicationUserStore :
        UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
        IApplicationUserStore
    {
        public ApplicationUserStore() : base(new ApplicationDbContext())
        {

        }

        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }


    public class ApplicationRoleStore<TRole> : 
        RoleStore<TRole, int, ApplicationUserRole>, 
        IQueryableRoleStore<TRole, int>, 
        IRoleStore<TRole, int>, 
        IDisposable 
        where TRole : ApplicationRole, new()
    {
        public ApplicationRoleStore(DbContext context) : base(context) { }
    }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base() { Name = roleName; }
    }

    public class ApplicationUserRole : IdentityUserRole<int> { }

    public class ApplicationUserLogin : IdentityUserLogin<int> { }

    public class ApplicationUserClaim : IdentityUserClaim<int> { }


    // TODO: Profiling by adding more properties: http://go.microsoft.com/fwlink/?LinkID=317594 
    public class ApplicationUser :
            IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
            IUser<int>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }


}
