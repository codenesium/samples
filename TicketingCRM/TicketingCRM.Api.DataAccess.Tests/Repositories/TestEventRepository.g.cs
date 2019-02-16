using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class EventRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
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
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);

			Event entity = new Event();
			entity.SetProperties(default(int), "B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
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
			entity.SetProperties(default(int), "B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<Event>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), "B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Event>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), "B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Event>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), "B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Event>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>32c489492007f0a8dd66eb0a50e23210</Hash>
</Codenesium>*/