
using System.Data.Entity;

namespace quiz_manager
{
    public class UserDbContext : DbContext
    {
        //public UserDbContext() : base("UserDbContext") { }
        //public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("dbo");
        //    modelBuilder.Entity<User>().ToTable("Users").HasKey(e => e.Id);
        //    modelBuilder.Entity<User>().HasIndex(e => new { e.Id, e.Email}).IsUnique(true);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
