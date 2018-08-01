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
	public partial class EventRelatedDocumentRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventRelatedDocumentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventRelatedDocumentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventRelatedDocument")]
	[Trait("Area", "Repositories")]
	public partial class EventRelatedDocumentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);

			EventRelatedDocument entity = new EventRelatedDocument();
			context.Set<EventRelatedDocument>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);

			EventRelatedDocument entity = new EventRelatedDocument();
			context.Set<EventRelatedDocument>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);

			var entity = new EventRelatedDocument();
			await repository.Create(entity);

			var record = await context.Set<EventRelatedDocument>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);
			EventRelatedDocument entity = new EventRelatedDocument();
			context.Set<EventRelatedDocument>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<EventRelatedDocument>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);
			EventRelatedDocument entity = new EventRelatedDocument();
			context.Set<EventRelatedDocument>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EventRelatedDocument());

			var modifiedRecord = context.Set<EventRelatedDocument>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EventRelatedDocumentRepository>> loggerMoc = EventRelatedDocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRelatedDocumentRepositoryMoc.GetContext();
			var repository = new EventRelatedDocumentRepository(loggerMoc.Object, context);
			EventRelatedDocument entity = new EventRelatedDocument();
			context.Set<EventRelatedDocument>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			EventRelatedDocument modifiedRecord = await context.Set<EventRelatedDocument>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>1c09d65700f1801df3fc3458a1fe4ea3</Hash>
</Codenesium>*/