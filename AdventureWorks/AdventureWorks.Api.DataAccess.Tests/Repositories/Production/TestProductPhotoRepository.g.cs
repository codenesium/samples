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
	public partial class ProductPhotoRepositoryMoc
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

		public static Mock<ILogger<ProductPhotoRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductPhotoRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Repositories")]
	public partial class ProductPhotoRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);

			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, BitConverter.GetBytes(2), "B");
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductPhotoID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);

			var entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, BitConverter.GetBytes(2), "B");
			await repository.Create(entity);

			var records = await context.Set<ProductPhoto>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, BitConverter.GetBytes(2), "B");
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductPhotoID);

			await repository.Update(record);

			var records = await context.Set<ProductPhoto>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, BitConverter.GetBytes(2), "B");
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<ProductPhoto>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			entity.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, BitConverter.GetBytes(2), "B");
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductPhotoID);

			var records = await context.Set<ProductPhoto>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>3ff579bc24e4d0316f85c5ff02ee7507</Hash>
</Codenesium>*/