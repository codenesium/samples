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
	public partial class EventTeacherRepositoryMoc
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

		public static Mock<ILogger<EventTeacherRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventTeacherRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Repositories")]
	public partial class EventTeacherRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			EventTeacher entity = new EventTeacher();
			entity.SetProperties(default(int), 1);
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.EventId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			var entity = new EventTeacher();
			entity.SetProperties(default(int), 1);
			await repository.Create(entity);

			var records = await context.Set<EventTeacher>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			entity.SetProperties(default(int), 1);
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.EventId);

			await repository.Update(record);

			var records = await context.Set<EventTeacher>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			entity.SetProperties(default(int), 1);
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<EventTeacher>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			entity.SetProperties(default(int), 1);
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.EventId);

			var records = await context.Set<EventTeacher>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a70e8b675d984072b627b905d7b8737e</Hash>
</Codenesium>*/