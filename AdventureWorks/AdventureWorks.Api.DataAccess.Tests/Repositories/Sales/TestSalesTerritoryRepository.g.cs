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
	public partial class SalesTerritoryRepositoryMoc
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

		public static Mock<ILogger<SalesTerritoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTerritoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Repositories")]
	public partial class SalesTerritoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			SalesTerritory entity = new SalesTerritory();
			entity.SetProperties(default(int), 2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TerritoryID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			var entity = new SalesTerritory();
			entity.SetProperties(default(int), 2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			await repository.Create(entity);

			var records = await context.Set<SalesTerritory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			entity.SetProperties(default(int), 2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TerritoryID);

			await repository.Update(record);

			var records = await context.Set<SalesTerritory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			entity.SetProperties(default(int), 2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<SalesTerritory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			entity.SetProperties(default(int), 2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TerritoryID);

			var records = await context.Set<SalesTerritory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>8ddbc9a27b1aca71876ac2848c600322</Hash>
</Codenesium>*/