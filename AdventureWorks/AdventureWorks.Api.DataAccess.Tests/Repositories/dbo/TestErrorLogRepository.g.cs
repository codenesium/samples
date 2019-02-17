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
	public partial class ErrorLogRepositoryMoc
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

		public static Mock<ILogger<ErrorLogRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ErrorLogRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Repositories")]
	public partial class ErrorLogRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			ErrorLog entity = new ErrorLog();
			entity.SetProperties(default(int), 2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ErrorLogID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			var entity = new ErrorLog();
			entity.SetProperties(default(int), 2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<ErrorLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			entity.SetProperties(default(int), 2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ErrorLogID);

			await repository.Update(record);

			var records = await context.Set<ErrorLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			entity.SetProperties(default(int), 2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ErrorLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			entity.SetProperties(default(int), 2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ErrorLogID);

			var records = await context.Set<ErrorLog>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ff2d73817468bc073d2ca8578eb7b6bc</Hash>
</Codenesium>*/