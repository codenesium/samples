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
	public partial class PipelineStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PipelineStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			PipelineStatu entity = new PipelineStatu();
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			PipelineStatu entity = new PipelineStatu();
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			var entity = new PipelineStatu();
			await repository.Create(entity);

			var record = await context.Set<PipelineStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PipelineStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PipelineStatu());

			var modifiedRecord = context.Set<PipelineStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PipelineStatu modifiedRecord = await context.Set<PipelineStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>88a84f6e14e45da97def0c6005ea074b</Hash>
</Codenesium>*/