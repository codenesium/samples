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
	public partial class PostLinkRepositoryMoc
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

		public static Mock<ILogger<PostLinkRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostLinkRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostLink")]
	[Trait("Area", "Repositories")]
	public partial class PostLinkRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			PostLink entity = new PostLink();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			var entity = new PostLink();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			await repository.Create(entity);

			var records = await context.Set<PostLink>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<PostLink>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<PostLink>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<PostLink>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>f007c9dc33e60a44a4d2d9d557f9bcd6</Hash>
</Codenesium>*/