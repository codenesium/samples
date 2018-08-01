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
	public partial class SalesOrderDetailRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesOrderDetailRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesOrderDetailRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "Repositories")]
	public partial class SalesOrderDetailRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);

			SalesOrderDetail entity = new SalesOrderDetail();
			context.Set<SalesOrderDetail>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);

			SalesOrderDetail entity = new SalesOrderDetail();
			context.Set<SalesOrderDetail>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);

			var entity = new SalesOrderDetail();
			await repository.Create(entity);

			var record = await context.Set<SalesOrderDetail>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);
			SalesOrderDetail entity = new SalesOrderDetail();
			context.Set<SalesOrderDetail>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesOrderDetail>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);
			SalesOrderDetail entity = new SalesOrderDetail();
			context.Set<SalesOrderDetail>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesOrderDetail());

			var modifiedRecord = context.Set<SalesOrderDetail>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesOrderDetailRepository>> loggerMoc = SalesOrderDetailRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderDetailRepositoryMoc.GetContext();
			var repository = new SalesOrderDetailRepository(loggerMoc.Object, context);
			SalesOrderDetail entity = new SalesOrderDetail();
			context.Set<SalesOrderDetail>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesOrderID);

			SalesOrderDetail modifiedRecord = await context.Set<SalesOrderDetail>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>fa8dcd4bbe4d4fa7da60e4e5399ea73f</Hash>
</Codenesium>*/