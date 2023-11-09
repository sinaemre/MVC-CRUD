using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Entities.Concrete;
using MVC_CRUD.Infrastructure.EntityTypeConfiguration.Concrete;

namespace MVC_CRUD.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
