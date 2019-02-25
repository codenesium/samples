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
	public partial class ProductSubcategoryRepositoryMoc
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

		public static Mock<ILogger<ProductSubcategoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductSubcategoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Repositories")]
	public partial class ProductSubcategoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductSubcategoryID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			var entity = new ProductSubcategory();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<ProductSubcategory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductSubcategoryID);

			await repository.Update(record);

			var records = await context.Set<ProductSubcategory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ProductSubcategory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductSubcategoryID);

			var records = await context.Set<ProductSubcategory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>638ff49f83f68132f33c812cd79f5d27</Hash>
</Codenesium>*/