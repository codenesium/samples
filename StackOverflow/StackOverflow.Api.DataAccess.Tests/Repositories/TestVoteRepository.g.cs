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
	public partial class VoteRepositoryMoc
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

		public static Mock<ILogger<VoteRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VoteRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Vote")]
	[Trait("Area", "Repositories")]
	public partial class VoteRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			Vote entity = new Vote();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			var entity = new Vote();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			await repository.Create(entity);

			var records = await context.Set<Vote>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Vote>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Vote>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Vote>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>b39d0323f81179a7f2e173244f0bc2a1</Hash>
</Codenesium>*/