using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductCategoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductCategoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductCategoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "Repositories")]
	public partial class ProductCategoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);

			ProductCategory entity = new ProductCategory();
			context.Set<ProductCategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);

			ProductCategory entity = new ProductCategory();
			context.Set<ProductCategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductCategoryID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);

			var entity = new ProductCategory();
			await repository.Create(entity);

			var record = await context.Set<ProductCategory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);
			ProductCategory entity = new ProductCategory();
			context.Set<ProductCategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductCategoryID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductCategory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);
			ProductCategory entity = new ProductCategory();
			context.Set<ProductCategory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductCategory());

			var modifiedRecord = context.Set<ProductCategory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductCategoryRepository>> loggerMoc = ProductCategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCategoryRepositoryMoc.GetContext();
			var repository = new ProductCategoryRepository(loggerMoc.Object, context);
			ProductCategory entity = new ProductCategory();
			context.Set<ProductCategory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductCategoryID);

			ProductCategory modifiedRecord = await context.Set<ProductCategory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>202a7f250602d653c614047e43ad9c68</Hash>
</Codenesium>*/