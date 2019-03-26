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
	public partial class ProductProductPhotoRepositoryMoc
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

		public static Mock<ILogger<ProductProductPhotoRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductProductPhotoRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "Repositories")]
	public partial class ProductProductPhotoRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);

			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);

			var entity = new ProductProductPhoto();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			await repository.Create(entity);

			var records = await context.Set<ProductProductPhoto>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var records = await context.Set<ProductProductPhoto>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ProductProductPhoto>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			var records = await context.Set<ProductProductPhoto>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>23f8ae1b173d3a2e38762454d8ceb8cf</Hash>
</Codenesium>*/