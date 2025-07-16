using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_TrendGiysi_Tekrar_.Models.Entities;

namespace MVC_TrendGiysi_Tekrar_.Models.Contexts
{
    public class GiysiContext : IdentityDbContext<AppUser, AppUserRole, string>
    {
        public GiysiContext(DbContextOptions<GiysiContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GiysiDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.Entity is BaseEntity baseEntity)
                    {
                        baseEntity.ModifiedDate = DateTime.Now;
                    }
                }
            }
            return base.SaveChanges();
        }




    }
}
