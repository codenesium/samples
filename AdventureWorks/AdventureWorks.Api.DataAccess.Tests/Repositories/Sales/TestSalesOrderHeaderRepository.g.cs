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
	public partial class SalesOrderHeaderRepositoryMoc
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

		public static Mock<ILogger<SalesOrderHeaderRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesOrderHeaderRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Repositories")]
	public partial class SalesOrderHeaderRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			SalesOrderHeader entity = new SalesOrderHeader();
			entity.SetProperties(default(int), "B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			var entity = new SalesOrderHeader();
			entity.SetProperties(default(int), "B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			await repository.Create(entity);

			var records = await context.Set<SalesOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			entity.SetProperties(default(int), "B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			await repository.Update(record);

			var records = await context.Set<SalesOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			entity.SetProperties(default(int), "B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<SalesOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			entity.SetProperties(default(int), "B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesOrderID);

			var records = await context.Set<SalesOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>56ab88c5da658a2656125e4fc8bd398b</Hash>
</Codenesium>*/