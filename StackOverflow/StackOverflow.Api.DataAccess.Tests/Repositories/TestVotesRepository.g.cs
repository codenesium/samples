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

namespace StackOverflowNS.Api.DataAccess
{
	public partial class VotesRepositoryMoc
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

		public static Mock<ILogger<VotesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VotesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Votes")]
	[Trait("Area", "Repositories")]
	public partial class VotesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			Votes entity = new Votes();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			var entity = new Votes();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			await repository.Create(entity);

			var records = await context.Set<Votes>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Votes>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Votes>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Votes>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a2fef5875e1fe600bf833b0f1c8227fc</Hash>
</Codenesium>*/