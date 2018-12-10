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
	public partial class TweetRepositoryMoc
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

		public static Mock<ILogger<TweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "Repositories")]
	public partial class TweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			Tweet entity = new Tweet();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 2, 1);
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			var entity = new Tweet();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 2, 1);
			await repository.Create(entity);

			var records = await context.Set<Tweet>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 2, 1);
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			await repository.Update(record);

			var records = await context.Set<Tweet>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 2, 1);
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Tweet>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 2, 1);
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TweetId);

			var records = await context.Set<Tweet>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c6ab3ab7d6f3aac30d15dd363d486c0d</Hash>
</Codenesium>*/