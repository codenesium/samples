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
	public partial class PostHistoryRepositoryMoc
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

		public static Mock<ILogger<PostHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Repositories")]
	public partial class PostHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			PostHistory entity = new PostHistory();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, "B", "B", "B", 2);
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			var entity = new PostHistory();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, "B", "B", "B", 2);
			await repository.Create(entity);

			var records = await context.Set<PostHistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, "B", "B", "B", 2);
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<PostHistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, "B", "B", "B", 2);
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<PostHistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, "B", "B", "B", 2);
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<PostHistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>291ff0b838150621e7ed92260de94a39</Hash>
</Codenesium>*/