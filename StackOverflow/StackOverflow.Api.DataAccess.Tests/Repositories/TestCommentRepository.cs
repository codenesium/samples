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
	public partial class CommentRepositoryMoc
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

		public static Mock<ILogger<CommentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CommentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "Repositories")]
	public partial class CommentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			Comment entity = new Comment();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			var entity = new Comment();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Comment>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Comment>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Comment>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Comment>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>bfeaa59e1a7645790f5321214bf1ca92</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/