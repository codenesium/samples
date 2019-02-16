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

namespace TwitterNS.Api.DataAccess
{
	public partial class FollowerRepositoryMoc
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

		public static Mock<ILogger<FollowerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FollowerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "Repositories")]
	public partial class FollowerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			Follower entity = new Follower();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			var entity = new Follower();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Follower>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Follower>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Follower>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Follower>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>757f4a684fa1c685eddfa21846fa92b7</Hash>
</Codenesium>*/