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
	public partial class SalesPersonRepositoryMoc
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

		public static Mock<ILogger<SalesPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Repositories")]
	public partial class SalesPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1m.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			SalesPerson entity = new SalesPerson();
			entity.SetProperties(default(int), 2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			var entity = new SalesPerson();
			entity.SetProperties(default(int), 2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			await repository.Create(entity);

			var records = await context.Set<SalesPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			entity.SetProperties(default(int), 2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var records = await context.Set<SalesPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			entity.SetProperties(default(int), 2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SalesPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			entity.SetProperties(default(int), 2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			var records = await context.Set<SalesPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>131c1d0ce42e7b3209b5c1ab42b0ec70</Hash>
</Codenesium>*/