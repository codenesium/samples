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
	public partial class SalesPersonQuotaHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesPersonQuotaHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesPersonQuotaHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "Repositories")]
	public partial class SalesPersonQuotaHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);

			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			context.Set<SalesPersonQuotaHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);

			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			context.Set<SalesPersonQuotaHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);

			var entity = new SalesPersonQuotaHistory();
			await repository.Create(entity);

			var record = await context.Set<SalesPersonQuotaHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);
			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			context.Set<SalesPersonQuotaHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesPersonQuotaHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);
			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			context.Set<SalesPersonQuotaHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesPersonQuotaHistory());

			var modifiedRecord = context.Set<SalesPersonQuotaHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesPersonQuotaHistoryRepository>> loggerMoc = SalesPersonQuotaHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonQuotaHistoryRepositoryMoc.GetContext();
			var repository = new SalesPersonQuotaHistoryRepository(loggerMoc.Object, context);
			SalesPersonQuotaHistory entity = new SalesPersonQuotaHistory();
			context.Set<SalesPersonQuotaHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			SalesPersonQuotaHistory modifiedRecord = await context.Set<SalesPersonQuotaHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>2e734f2f739145e46fb46e437322c360</Hash>
</Codenesium>*/