////using Microsoft.EntityFrameworkCore.Design;
////using Microsoft.EntityFrameworkCore;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace atomic.chicken.infrastructure.Repository.EFCore
////{
////	public class DatabaseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
////	{

////		private const string connectionString =

////			@"Server=(localdb)\mssqllocaldb;Database=wwtravelclub;

////                Trusted_Connection=True;MultipleActiveResultSets=true";

////		public DatabaseContext CreateDbContext(params string[] args)

////		{

////			var builder = new DbContextOptionsBuilder<DatabaseContext>();



////			builder.UseSqlServer(connectionString);

////			return new DatabaseContext(builder.Options);

////		}

////	}
////}
