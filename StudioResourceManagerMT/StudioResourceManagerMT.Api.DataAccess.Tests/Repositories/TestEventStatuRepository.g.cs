using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class EventStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "Repositories")]
	public partial class EventStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);

			EventStatu entity = new EventStatu();
			context.Set<EventStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);

			EventStatu entity = new EventStatu();
			context.Set<EventStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);

			var entity = new EventStatu();
			await repository.Create(entity);

			var record = await context.Set<EventStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);
			EventStatu entity = new EventStatu();
			context.Set<EventStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<EventStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);
			EventStatu entity = new EventStatu();
			context.Set<EventStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EventStatu());

			var modifiedRecord = context.Set<EventStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);
			EventStatu entity = new EventStatu();
			context.Set<EventStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			EventStatu modifiedRecord = await context.Set<EventStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EventStatuRepository>> loggerMoc = EventStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatuRepositoryMoc.GetContext();
			var repository = new EventStatuRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e58e480e11f73b2cf3c4972171ac5b62</Hash>
</Codenesium>*/