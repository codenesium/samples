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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesTerritoryRepository>> loggerMoc = SalesTerritoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTerritoryRepositoryMoc.GetContext();
			var repository = new SalesTerritoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>39ee7a108016aeed17bec8a16ee62a9e</Hash>
</Codenesium>*/