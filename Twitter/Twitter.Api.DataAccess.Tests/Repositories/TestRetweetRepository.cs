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
	public partial class RetweetRepositoryMoc
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

		public static Mock<ILogger<RetweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RetweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "Repositories")]
	public partial class RetweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			Retweet entity = new Retweet();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			var entity = new Retweet();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			await repository.Create(entity);

			var records = await context.Set<Retweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Retweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Retweet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Retweet>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>30093b0356a270fb82d93772c3edd98c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/