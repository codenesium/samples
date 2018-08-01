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
	public partial class ProductVendorRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductVendorRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductVendorRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductVendor")]
	[Trait("Area", "Repositories")]
	public partial class ProductVendorRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);

			ProductVendor entity = new ProductVendor();
			context.Set<ProductVendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);

			ProductVendor entity = new ProductVendor();
			context.Set<ProductVendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);

			var entity = new ProductVendor();
			await repository.Create(entity);

			var record = await context.Set<ProductVendor>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);
			ProductVendor entity = new ProductVendor();
			context.Set<ProductVendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductVendor>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);
			ProductVendor entity = new ProductVendor();
			context.Set<ProductVendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductVendor());

			var modifiedRecord = context.Set<ProductVendor>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductVendorRepository>> loggerMoc = ProductVendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductVendorRepositoryMoc.GetContext();
			var repository = new ProductVendorRepository(loggerMoc.Object, context);
			ProductVendor entity = new ProductVendor();
			context.Set<ProductVendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			ProductVendor modifiedRecord = await context.Set<ProductVendor>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f4c20fd98b59e2518792990f4a7c821b</Hash>
</Codenesium>*/