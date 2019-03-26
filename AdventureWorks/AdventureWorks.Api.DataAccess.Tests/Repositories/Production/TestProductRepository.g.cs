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
	public partial class ProductRepositoryMoc
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

		public static Mock<ILogger<ProductRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "Repositories")]
	public partial class ProductRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			Product entity = new Product();
			entity.SetProperties(default(int), "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			var entity = new Product();
			entity.SetProperties(default(int), "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			await repository.Create(entity);

			var records = await context.Set<Product>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			entity.SetProperties(default(int), "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var records = await context.Set<Product>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			entity.SetProperties(default(int), "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Product>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			entity.SetProperties(default(int), "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			var records = await context.Set<Product>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>837519c5b127202d6dd5b381c5ac10c6</Hash>
</Codenesium>*/