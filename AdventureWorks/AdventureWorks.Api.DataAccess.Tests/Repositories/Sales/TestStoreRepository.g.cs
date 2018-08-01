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
	public partial class StoreRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<StoreRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<StoreRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Store")]
	[Trait("Area", "Repositories")]
	public partial class StoreRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			Store entity = new Store();
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			Store entity = new Store();
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);

			var entity = new Store();
			await repository.Create(entity);

			var record = await context.Set<Store>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Store>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Store());

			var modifiedRecord = context.Set<Store>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<StoreRepository>> loggerMoc = StoreRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StoreRepositoryMoc.GetContext();
			var repository = new StoreRepository(loggerMoc.Object, context);
			Store entity = new Store();
			context.Set<Store>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			Store modifiedRecord = await context.Set<Store>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>552485719ac8a56c0dd17634b7825180</Hash>
</Codenesium>*/