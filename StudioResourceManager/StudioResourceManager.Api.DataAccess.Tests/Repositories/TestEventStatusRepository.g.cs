using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class EventStatusRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "Repositories")]
	public partial class EventStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);

			EventStatus entity = new EventStatus();
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);

			EventStatus entity = new EventStatus();
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);

			var entity = new EventStatus();
			await repository.Create(entity);

			var record = await context.Set<EventStatus>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<EventStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EventStatus());

			var modifiedRecord = context.Set<EventStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			EventStatus modifiedRecord = await context.Set<EventStatus>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>a0dbdee1daaad1c9664e622ec162b544</Hash>
</Codenesium>*/