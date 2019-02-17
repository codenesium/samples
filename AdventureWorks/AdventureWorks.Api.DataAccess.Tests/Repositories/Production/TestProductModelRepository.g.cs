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
	public partial class ProductModelRepositoryMoc
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

		public static Mock<ILogger<ProductModelRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductModelRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModel")]
	[Trait("Area", "Repositories")]
	public partial class ProductModelRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);

			ProductModel entity = new ProductModel();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductModel>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductModelID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);

			var entity = new ProductModel();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<ProductModel>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);
			ProductModel entity = new ProductModel();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductModel>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductModelID);

			await repository.Update(record);

			var records = await context.Set<ProductModel>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);
			ProductModel entity = new ProductModel();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductModel>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ProductModel>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);
			ProductModel entity = new ProductModel();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductModel>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductModelID);

			var records = await context.Set<ProductModel>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
			var repository = new ProductModelRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>626b14948fcb55f9abfb52d6d6fb530c</Hash>
</Codenesium>*/