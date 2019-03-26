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
	public partial class FollowingRepositoryMoc
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

		public static Mock<ILogger<FollowingRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FollowingRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "Repositories")]
	public partial class FollowingRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			Following entity = new Following();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			var entity = new Following();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<Following>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			await repository.Update(record);

			var records = await context.Set<Following>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Following>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.UserId);

			var records = await context.Set<Following>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>bf1cfede88437125e9cff8bacfbfc5ab</Hash>
</Codenesium>*/