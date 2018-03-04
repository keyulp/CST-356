using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Lab_Week_5.Data.Entities;

namespace Lab_Week_5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public virtual DbSet<Kid> Kids { get; set; }

        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {
            // intentionally left blank
        }
    }
}