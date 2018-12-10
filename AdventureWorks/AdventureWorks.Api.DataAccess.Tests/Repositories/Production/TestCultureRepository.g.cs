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
	public partial class CultureRepositoryMoc
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

		public static Mock<ILogger<CultureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CultureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Culture")]
	[Trait("Area", "Repositories")]
	public partial class CultureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			Culture entity = new Culture();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			var entity = new Culture();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<Culture>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			await repository.Update(record);

			var records = await context.Set<Culture>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Culture>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CultureID);

			var records = await context.Set<Culture>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>fb44d7eb3faf766e8516786e1e466e6f</Hash>
</Codenesium>*/