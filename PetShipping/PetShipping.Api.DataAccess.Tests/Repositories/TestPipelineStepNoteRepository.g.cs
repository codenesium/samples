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
	public partial class PipelineStepNoteRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PipelineStepNoteRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStepNoteRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStepNoteRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);

			PipelineStepNote entity = new PipelineStepNote();
			context.Set<PipelineStepNote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);

			PipelineStepNote entity = new PipelineStepNote();
			context.Set<PipelineStepNote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);

			var entity = new PipelineStepNote();
			await repository.Create(entity);

			var record = await context.Set<PipelineStepNote>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);
			PipelineStepNote entity = new PipelineStepNote();
			context.Set<PipelineStepNote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PipelineStepNote>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);
			PipelineStepNote entity = new PipelineStepNote();
			context.Set<PipelineStepNote>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PipelineStepNote());

			var modifiedRecord = context.Set<PipelineStepNote>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);
			PipelineStepNote entity = new PipelineStepNote();
			context.Set<PipelineStepNote>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PipelineStepNote modifiedRecord = await context.Set<PipelineStepNote>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineStepNoteRepository>> loggerMoc = PipelineStepNoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepNoteRepositoryMoc.GetContext();
			var repository = new PipelineStepNoteRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d75451fd2ea0cdae7f5aa187b39d37fc</Hash>
</Codenesium>*/