

using Microsoft.EntityFrameworkCore;
using StoreyChallenge.Models;

namespace StoreyChallenge.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Item>()
                .HasQueryFilter(i => !i.IsDeleted);

       

            // Datos iniciales para la tabla Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Iluminación", IsDeleted = false },
                new Category { Id = 2, Name = "Refrigeración", IsDeleted = false }
            );

            // Datos iniciales para la tabla Item
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Element = "Lámpara Led de 5w", Value = 5, CategoryId = 1 },
                new Item { Id = 2, Element = "Lámpara Led de 10w", Value = 10, CategoryId = 1 },
                new Item { Id = 3, Element = "Lámpara Incandescente 40w", Value = 40, CategoryId = 1 },
                new Item { Id = 4, Element = "Lámpara Incandescente de 100w", Value = 100, CategoryId = 1 },
                new Item { Id = 5, Element = "Lámpara Incandescente de 200w", Value = 200, CategoryId = 1 },
                new Item { Id = 6, Element = "Heladera", Value = 1000, CategoryId = 2 },
                new Item { Id = 7, Element = "Freezer", Value = 1500, CategoryId = 2 }
            );
       
        }
    }
}
