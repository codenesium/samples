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
	public partial class SalesTerritoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesTerritoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTerritoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Repositories")]
	public partial class SalesTerritoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			SalesTerritory entity = new SalesTerritory();
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			SalesTerritory entity = new SalesTerritory();
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TerritoryID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			var entity = new SalesTerritory();
			await repository.Create(entity);

			var record = await context.Set<SalesTerritory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TerritoryID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesTerritory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesTerritory());

			var modifiedRecord = context.Set<SalesTerritory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);
			SalesTerritory entity = new SalesTerritory();
			context.Set<SalesTerritory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TerritoryID);

			SalesTerritory modifiedRecord = await context.Set<SalesTerritory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f22df4de675e16a8f149db32290592bb</Hash>
</Codenesium>*/