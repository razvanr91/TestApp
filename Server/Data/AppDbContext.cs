using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Call the base version as well else we get an error later
			base.OnModelCreating(modelBuilder);

			Category[] categoriesToSeed = new Category[3];

			for (int i = 0; i < categoriesToSeed.Length; i++)
			{
				categoriesToSeed[i] = new Category
				{
					ThumbnailImagePath = "uploads/placeholder.jpg",
					Name = $"Category {i}",
					Description = $"A description of cateogy {i}"
				};
			}

			modelBuilder.Entity<Category>().HasData(categoriesToSeed);
		}
	}
}
