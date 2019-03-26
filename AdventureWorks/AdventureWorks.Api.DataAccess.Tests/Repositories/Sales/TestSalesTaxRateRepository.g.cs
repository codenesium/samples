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
	public partial class SalesTaxRateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options, null);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<SalesTaxRateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTaxRateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Repositories")]
	public partial class SalesTaxRateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			var entity = new SalesTaxRate();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			await repository.Create(entity);

			var records = await context.Set<SalesTaxRate>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			await repository.Update(record);

			var records = await context.Set<SalesTaxRate>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SalesTaxRate>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesTaxRateID);

			var records = await context.Set<SalesTaxRate>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e3ef6751e89b18b1b9c78cd0ab41b6f4</Hash>
</Codenesium>*/