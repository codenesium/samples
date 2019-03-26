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
	public partial class ProductReviewRepositoryMoc
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

		public static Mock<ILogger<ProductReviewRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductReviewRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductReview")]
	[Trait("Area", "Repositories")]
	public partial class ProductReviewRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);

			ProductReview entity = new ProductReview();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductReviewID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);

			var entity = new ProductReview();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<ProductReview>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductReviewID);

			await repository.Update(record);

			var records = await context.Set<ProductReview>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ProductReview>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			entity.SetProperties(default(int), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductReviewID);

			var records = await context.Set<ProductReview>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>543c0aac8262e33a916a499fb2a9a3da</Hash>
</Codenesium>*/