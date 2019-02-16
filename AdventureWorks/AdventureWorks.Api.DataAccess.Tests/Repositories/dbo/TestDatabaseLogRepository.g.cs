using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class DatabaseLogRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<DatabaseLogRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DatabaseLogRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "Repositories")]
	public partial class DatabaseLogRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);

			DatabaseLog entity = new DatabaseLog();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			context.Set<DatabaseLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DatabaseLogID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);

			var entity = new DatabaseLog();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			await repository.Create(entity);

			var records = await context.Set<DatabaseLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);
			DatabaseLog entity = new DatabaseLog();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			context.Set<DatabaseLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DatabaseLogID);

			await repository.Update(record);

			var records = await context.Set<DatabaseLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);
			DatabaseLog entity = new DatabaseLog();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			context.Set<DatabaseLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<DatabaseLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);
			DatabaseLog entity = new DatabaseLog();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			context.Set<DatabaseLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.DatabaseLogID);

			var records = await context.Set<DatabaseLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
			var repository = new DatabaseLogRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e067c679c8830f5d27c64b6b8efe13a9</Hash>
</Codenesium>*/