using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Heuristics.TechEval.Core.Models;

namespace Heuristics.TechEval.Core {

	public class DataContext : DbContext, IDataContext {

		public DataContext() : base("Database") { }

		public DbSet<Member> Members { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
        int IDataContext.SaveChanges()
        {
            return SaveChanges();
        }
    }

	public interface IDataContext
	{
		DbSet<Member> Members { get; set; }
		DbSet<Category> Categories { get; set; }
		int SaveChanges();
	}
}