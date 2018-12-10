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
	public partial class PostRepositoryMoc
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

		public static Mock<ILogger<PostRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Post")]
	[Trait("Area", "Repositories")]
	public partial class PostRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			Post entity = new Post();
			entity.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			var entity = new Post();
			entity.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Post>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			entity.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Post>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			entity.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Post>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			entity.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Post>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2a131bf59820ef7eb49012408dafaaf4</Hash>
</Codenesium>*/