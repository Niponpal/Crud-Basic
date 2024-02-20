using Microsoft.EntityFrameworkCore;

namespace SMS.DataBase
{
	public class SchoolDb:DbContext
	{
        public SchoolDb(DbContextOptions<SchoolDb> dbContext):base(dbContext) 
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDb).Assembly);
		}
	}
}
