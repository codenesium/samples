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
	public partial class ProductCostHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductCostHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductCostHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductCostHistory")]
	[Trait("Area", "Repositories")]
	public partial class ProductCostHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);

			ProductCostHistory entity = new ProductCostHistory();
			context.Set<ProductCostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);

			ProductCostHistory entity = new ProductCostHistory();
			context.Set<ProductCostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);

			var entity = new ProductCostHistory();
			await repository.Create(entity);

			var record = await context.Set<ProductCostHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);
			ProductCostHistory entity = new ProductCostHistory();
			context.Set<ProductCostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductCostHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);
			ProductCostHistory entity = new ProductCostHistory();
			context.Set<ProductCostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductCostHistory());

			var modifiedRecord = context.Set<ProductCostHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProductCostHistoryRepository>> loggerMoc = ProductCostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductCostHistoryRepositoryMoc.GetContext();
			var repository = new ProductCostHistoryRepository(loggerMoc.Object, context);
			ProductCostHistory entity = new ProductCostHistory();
			context.Set<ProductCostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			ProductCostHistory modifiedRecord = await context.Set<ProductCostHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>67a8de7705217c706532f3395b70533c</Hash>
</Codenesium>*/