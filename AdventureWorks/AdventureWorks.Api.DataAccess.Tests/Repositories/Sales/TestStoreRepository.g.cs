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
	public partial class StoreRepositoryMoc
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

		public static Mock<ILogger<StoreRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<StoreRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Store")]
	[Trait("Area", "Repositories")]
	public partial class StoreRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			Store entity = new Store();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			var entity = new Store();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
			await repository.Create(entity);

			var records = await context.Set<Store>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var records = await context.Set<Store>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Store>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			var records = await context.Set<Store>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ba4c5de3974dede5ca8e932320bb400f</Hash>
</Codenesium>*/