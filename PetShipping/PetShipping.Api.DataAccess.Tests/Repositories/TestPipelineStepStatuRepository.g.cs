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
	public partial class PipelineStepStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PipelineStepStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStepStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStepStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			PipelineStepStatu entity = new PipelineStepStatu();
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			PipelineStepStatu entity = new PipelineStepStatu();
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			var entity = new PipelineStepStatu();
			await repository.Create(entity);

			var record = await context.Set<PipelineStepStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PipelineStepStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PipelineStepStatu());

			var modifiedRecord = context.Set<PipelineStepStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PipelineStepStatu modifiedRecord = await context.Set<PipelineStepStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>9b4a9e2ce63f850dd8190a5faa690aa1</Hash>
</Codenesium>*/