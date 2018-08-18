using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class WorkerPoolRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<WorkerPoolRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<WorkerPoolRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "WorkerPool")]
	[Trait("Area", "Repositories")]
	public partial class WorkerPoolRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);

			WorkerPool entity = new WorkerPool();
			context.Set<WorkerPool>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);

			WorkerPool entity = new WorkerPool();
			context.Set<WorkerPool>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);

			var entity = new WorkerPool();
			await repository.Create(entity);

			var record = await context.Set<WorkerPool>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);
			WorkerPool entity = new WorkerPool();
			context.Set<WorkerPool>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<WorkerPool>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);
			WorkerPool entity = new WorkerPool();
			context.Set<WorkerPool>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new WorkerPool());

			var modifiedRecord = context.Set<WorkerPool>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<WorkerPoolRepository>> loggerMoc = WorkerPoolRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerPoolRepositoryMoc.GetContext();
			var repository = new WorkerPoolRepository(loggerMoc.Object, context);
			WorkerPool entity = new WorkerPool();
			context.Set<WorkerPool>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			WorkerPool modifiedRecord = await context.Set<WorkerPool>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>8322e14ba49813f7af05552b64b9c616</Hash>
</Codenesium>*/