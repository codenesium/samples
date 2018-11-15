using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductReviewRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			ProductReview entity = new ProductReview();
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);

			ProductReview entity = new ProductReview();
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
			await repository.Create(entity);

			var record = await context.Set<ProductReview>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductReviewID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductReview>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductReview());

			var modifiedRecord = context.Set<ProductReview>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
			var repository = new ProductReviewRepository(loggerMoc.Object, context);
			ProductReview entity = new ProductReview();
			context.Set<ProductReview>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductReviewID);

			ProductReview modifiedRecord = await context.Set<ProductReview>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
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
    <Hash>b3f379b0b975d71e549ee64fce358951</Hash>
</Codenesium>*/