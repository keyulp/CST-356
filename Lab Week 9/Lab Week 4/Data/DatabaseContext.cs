using System.Data.Entity;
using Lab_Week_4.Data.Entities;

namespace Lab_Week_4.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDBInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Kid> Kids { get; set; }

        public class AppDBInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {

        }
    }
}