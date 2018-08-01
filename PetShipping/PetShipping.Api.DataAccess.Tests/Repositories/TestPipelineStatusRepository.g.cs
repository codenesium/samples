using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStatusRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PipelineStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);

			PipelineStatus entity = new PipelineStatus();
			context.Set<PipelineStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);

			PipelineStatus entity = new PipelineStatus();
			context.Set<PipelineStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);

			var entity = new PipelineStatus();
			await repository.Create(entity);

			var record = await context.Set<PipelineStatus>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);
			PipelineStatus entity = new PipelineStatus();
			context.Set<PipelineStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PipelineStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);
			PipelineStatus entity = new PipelineStatus();
			context.Set<PipelineStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PipelineStatus());

			var modifiedRecord = context.Set<PipelineStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PipelineStatusRepository>> loggerMoc = PipelineStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatusRepositoryMoc.GetContext();
			var repository = new PipelineStatusRepository(loggerMoc.Object, context);
			PipelineStatus entity = new PipelineStatus();
			context.Set<PipelineStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PipelineStatus modifiedRecord = await context.Set<PipelineStatus>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>55d7cac78409a4e4ed6a82ba2b4a5aaf</Hash>
</Codenesium>*/