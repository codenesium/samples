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

namespace StudioResourceManagerMTNS.Api.DataAccess
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
			var context = new ApplicationDbContext(options.Options, null);
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

			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

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
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
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
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Event>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Event>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Event>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EventRepository>> loggerMoc = EventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventRepositoryMoc.GetContext();
			var repository = new EventRepository(loggerMoc.Object, context);
			Event entity = new Event();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<Event>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Event>().ToListAsync();

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
    <Hash>e81c4a416b298218c2a5ac723d26118b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/