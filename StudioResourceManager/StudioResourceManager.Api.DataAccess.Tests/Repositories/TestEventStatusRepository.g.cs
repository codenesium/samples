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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class EventStatusRepositoryMoc
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
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);

			EventStatus entity = new EventStatus();
			entity.SetProperties(default(int), "B");
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
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<EventStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			entity.SetProperties(default(int), "B");
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<EventStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			entity.SetProperties(default(int), "B");
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<EventStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);
			EventStatus entity = new EventStatus();
			entity.SetProperties(default(int), "B");
			context.Set<EventStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<EventStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EventStatusRepository>> loggerMoc = EventStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStatusRepositoryMoc.GetContext();
			var repository = new EventStatusRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6102997a0e4bb03482b11aebc1f1a3ed</Hash>
</Codenesium>*/