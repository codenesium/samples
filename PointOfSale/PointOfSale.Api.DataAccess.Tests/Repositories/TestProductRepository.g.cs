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

namespace PointOfSaleNS.Api.DataAccess
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
			var records = await repository.All(1, 0, true.ToString());

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
			entity.SetProperties(default(int), true, "B", "B", 2m, 2);
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			var entity = new Product();
			entity.SetProperties(default(int), true, "B", "B", 2m, 2);
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
			entity.SetProperties(default(int), true, "B", "B", 2m, 2);
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

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
			entity.SetProperties(default(int), true, "B", "B", 2m, 2);
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
			entity.SetProperties(default(int), true, "B", "B", 2m, 2);
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

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
    <Hash>916dc86451c6b41fa77ccff8ac78c54b</Hash>
</Codenesium>*/