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
	public partial class QuoteTweetRepositoryMoc
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

		public static Mock<ILogger<QuoteTweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<QuoteTweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Repositories")]
	public partial class QuoteTweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.QuoteTweetId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			var entity = new QuoteTweet();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			await repository.Create(entity);

			var records = await context.Set<QuoteTweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.QuoteTweetId);

			await repository.Update(record);

			var records = await context.Set<QuoteTweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<QuoteTweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.QuoteTweetId);

			var records = await context.Set<QuoteTweet>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>befd13e5c96154f4eb14d7ce70f7e586</Hash>
</Codenesium>*/