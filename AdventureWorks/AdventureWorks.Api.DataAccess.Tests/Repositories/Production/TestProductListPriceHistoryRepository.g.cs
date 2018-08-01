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
	public partial class ProductListPriceHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductListPriceHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductListPriceHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "Repositories")]
	public partial class ProductListPriceHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);

			ProductListPriceHistory entity = new ProductListPriceHistory();
			context.Set<ProductListPriceHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);

			ProductListPriceHistory entity = new ProductListPriceHistory();
			context.Set<ProductListPriceHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);

			var entity = new ProductListPriceHistory();
			await repository.Create(entity);

			var record = await context.Set<ProductListPriceHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);
			ProductListPriceHistory entity = new ProductListPriceHistory();
			context.Set<ProductListPriceHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductListPriceHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);
			ProductListPriceHistory entity = new ProductListPriceHistory();
			context.Set<ProductListPriceHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductListPriceHistory());

			var modifiedRecord = context.Set<ProductListPriceHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductListPriceHistoryRepository>> loggerMoc = ProductListPriceHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductListPriceHistoryRepositoryMoc.GetContext();
			var repository = new ProductListPriceHistoryRepository(loggerMoc.Object, context);
			ProductListPriceHistory entity = new ProductListPriceHistory();
			context.Set<ProductListPriceHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			ProductListPriceHistory modifiedRecord = await context.Set<ProductListPriceHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>038078655d1ab581e2fccfeb8da3926d</Hash>
</Codenesium>*/