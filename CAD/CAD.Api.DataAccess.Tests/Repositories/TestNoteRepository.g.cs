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

namespace CADNS.Api.DataAccess
{
	public partial class NoteRepositoryMoc
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

		public static Mock<ILogger<NoteRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<NoteRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Note")]
	[Trait("Area", "Repositories")]
	public partial class NoteRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);

			Note entity = new Note();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			context.Set<Note>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);

			var entity = new Note();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Note>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);
			Note entity = new Note();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			context.Set<Note>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Note>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);
			Note entity = new Note();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			context.Set<Note>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Note>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);
			Note entity = new Note();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			context.Set<Note>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Note>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<NoteRepository>> loggerMoc = NoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = NoteRepositoryMoc.GetContext();
			var repository = new NoteRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6541bf5e654ec75a40724752e297884f</Hash>
</Codenesium>*/