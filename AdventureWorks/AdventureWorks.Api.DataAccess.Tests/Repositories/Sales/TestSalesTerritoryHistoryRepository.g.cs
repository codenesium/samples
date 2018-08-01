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
	public partial class SalesTerritoryHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesTerritoryHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTerritoryHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritoryHistory")]
	[Trait("Area", "Repositories")]
	public partial class SalesTerritoryHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);

			SalesTerritoryHistory entity = new SalesTerritoryHistory();
			context.Set<SalesTerritoryHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);

			SalesTerritoryHistory entity = new SalesTerritoryHistory();
			context.Set<SalesTerritoryHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);

			var entity = new SalesTerritoryHistory();
			await repository.Create(entity);

			var record = await context.Set<SalesTerritoryHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);
			SalesTerritoryHistory entity = new SalesTerritoryHistory();
			context.Set<SalesTerritoryHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesTerritoryHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);
			SalesTerritoryHistory entity = new SalesTerritoryHistory();
			context.Set<SalesTerritoryHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesTerritoryHistory());

			var modifiedRecord = context.Set<SalesTerritoryHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesTerritoryHistoryRepository>> loggerMoc = SalesTerritoryHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryHistoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryHistoryRepository(loggerMoc.Object, context);
			SalesTerritoryHistory entity = new SalesTerritoryHistory();
			context.Set<SalesTerritoryHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			SalesTerritoryHistory modifiedRecord = await context.Set<SalesTerritoryHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>4942e3a3f2e0fe51123d808ad2d8ae2c</Hash>
</Codenesium>*/