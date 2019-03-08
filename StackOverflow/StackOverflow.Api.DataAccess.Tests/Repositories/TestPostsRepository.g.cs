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
	public partial class PostsRepositoryMoc
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

		public static Mock<ILogger<PostsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Posts")]
	[Trait("Area", "Repositories")]
	public partial class PostsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			Posts entity = new Posts();
			entity.SetProperties(default(int), 2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			var entity = new Posts();
			entity.SetProperties(default(int), 2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Posts>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			entity.SetProperties(default(int), 2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Posts>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			entity.SetProperties(default(int), 2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Posts>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			entity.SetProperties(default(int), 2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Posts>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>050e875125a03c9cb2264efcdc096881</Hash>
</Codenesium>*/