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
	public partial class WorkOrderRoutingRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<WorkOrderRoutingRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<WorkOrderRoutingRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrderRouting")]
	[Trait("Area", "Repositories")]
	public partial class WorkOrderRoutingRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);

			WorkOrderRouting entity = new WorkOrderRouting();
			context.Set<WorkOrderRouting>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);

			WorkOrderRouting entity = new WorkOrderRouting();
			context.Set<WorkOrderRouting>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.WorkOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);

			var entity = new WorkOrderRouting();
			await repository.Create(entity);

			var record = await context.Set<WorkOrderRouting>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);
			WorkOrderRouting entity = new WorkOrderRouting();
			context.Set<WorkOrderRouting>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.WorkOrderID);

			await repository.Update(record);

			var modifiedRecord = context.Set<WorkOrderRouting>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);
			WorkOrderRouting entity = new WorkOrderRouting();
			context.Set<WorkOrderRouting>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new WorkOrderRouting());

			var modifiedRecord = context.Set<WorkOrderRouting>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<WorkOrderRoutingRepository>> loggerMoc = WorkOrderRoutingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRoutingRepositoryMoc.GetContext();
			var repository = new WorkOrderRoutingRepository(loggerMoc.Object, context);
			WorkOrderRouting entity = new WorkOrderRouting();
			context.Set<WorkOrderRouting>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.WorkOrderID);

			WorkOrderRouting modifiedRecord = await context.Set<WorkOrderRouting>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>90c0e92c85cc52fff96b32d9078310ee</Hash>
</Codenesium>*/