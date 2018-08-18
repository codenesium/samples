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
	public partial class WorkerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<WorkerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<WorkerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Worker")]
	[Trait("Area", "Repositories")]
	public partial class WorkerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);

			Worker entity = new Worker();
			context.Set<Worker>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);

			Worker entity = new Worker();
			context.Set<Worker>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);

			var entity = new Worker();
			await repository.Create(entity);

			var record = await context.Set<Worker>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);
			Worker entity = new Worker();
			context.Set<Worker>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Worker>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);
			Worker entity = new Worker();
			context.Set<Worker>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Worker());

			var modifiedRecord = context.Set<Worker>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<WorkerRepository>> loggerMoc = WorkerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkerRepositoryMoc.GetContext();
			var repository = new WorkerRepository(loggerMoc.Object, context);
			Worker entity = new Worker();
			context.Set<Worker>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Worker modifiedRecord = await context.Set<Worker>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>828caf446df94fca513150340203a56c</Hash>
</Codenesium>*/