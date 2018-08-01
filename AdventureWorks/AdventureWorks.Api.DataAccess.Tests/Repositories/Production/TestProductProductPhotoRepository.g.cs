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
	public partial class ProductProductPhotoRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			ProductProductPhoto entity = new ProductProductPhoto();
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);

			ProductProductPhoto entity = new ProductProductPhoto();
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
			await repository.Create(entity);

			var record = await context.Set<ProductProductPhoto>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductProductPhoto>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductProductPhoto());

			var modifiedRecord = context.Set<ProductProductPhoto>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductProductPhotoRepository>> loggerMoc = ProductProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductProductPhotoRepository(loggerMoc.Object, context);
			ProductProductPhoto entity = new ProductProductPhoto();
			context.Set<ProductProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			ProductProductPhoto modifiedRecord = await context.Set<ProductProductPhoto>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>143b59c9ecc48889de5f0d3236177599</Hash>
</Codenesium>*/