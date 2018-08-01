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
	public partial class EventRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Event")]
	[Trait("Area", "Repositories")]
	public partial class EventRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);

			Event entity = new Event();
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);

			Event entity = new Event();
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);

			var entity = new Event();
			await repository.Create(entity);

			var record = await context.Set<Event>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Event>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Event());

			var modifiedRecord = context.Set<Event>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Event modifiedRecord = await context.Set<Event>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>31eace11dbb3b8c4b247238ab67a57ab</Hash>
</Codenesium>*/