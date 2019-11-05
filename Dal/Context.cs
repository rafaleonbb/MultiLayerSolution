using Microsoft.EntityFrameworkCore;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Dal
{
	public class Context : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite ("Data Source=MultiLayerSolution.db;");
		}
	}
}
