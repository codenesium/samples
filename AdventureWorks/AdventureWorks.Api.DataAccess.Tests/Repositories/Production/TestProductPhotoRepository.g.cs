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
	public partial class ProductPhotoRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			ProductPhoto entity = new ProductPhoto();
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);

			ProductPhoto entity = new ProductPhoto();
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
			await repository.Create(entity);

			var record = await context.Set<ProductPhoto>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductPhotoID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductPhoto>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductPhoto());

			var modifiedRecord = context.Set<ProductPhoto>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductPhotoRepository>> loggerMoc = ProductPhotoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductPhotoRepositoryMoc.GetContext();
			var repository = new ProductPhotoRepository(loggerMoc.Object, context);
			ProductPhoto entity = new ProductPhoto();
			context.Set<ProductPhoto>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductPhotoID);

			ProductPhoto modifiedRecord = await context.Set<ProductPhoto>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>35ad0549ac6d6f1dfc0b1acb7feb975e</Hash>
</Codenesium>*/