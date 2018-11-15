using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStepDestinationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PipelineStepDestinationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStepDestinationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStepDestinationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);

			PipelineStepDestination entity = new PipelineStepDestination();
			context.Set<PipelineStepDestination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);

			PipelineStepDestination entity = new PipelineStepDestination();
			context.Set<PipelineStepDestination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);

			var entity = new PipelineStepDestination();
			await repository.Create(entity);

			var record = await context.Set<PipelineStepDestination>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);
			PipelineStepDestination entity = new PipelineStepDestination();
			context.Set<PipelineStepDestination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PipelineStepDestination>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);
			PipelineStepDestination entity = new PipelineStepDestination();
			context.Set<PipelineStepDestination>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PipelineStepDestination());

			var modifiedRecord = context.Set<PipelineStepDestination>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);
			PipelineStepDestination entity = new PipelineStepDestination();
			context.Set<PipelineStepDestination>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PipelineStepDestination modifiedRecord = await context.Set<PipelineStepDestination>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineStepDestinationRepository>> loggerMoc = PipelineStepDestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepDestinationRepositoryMoc.GetContext();
			var repository = new PipelineStepDestinationRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>3bb40247e8813da7d162c385d9b21e7a</Hash>
</Codenesium>*/