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
	public partial class TagRepositoryMoc
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

		public static Mock<ILogger<TagRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TagRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "Repositories")]
	public partial class TagRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			Tag entity = new Tag();
			entity.SetProperties(default(int), 2, 2, "B", 2);
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			var entity = new Tag();
			entity.SetProperties(default(int), 2, 2, "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Tag>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			entity.SetProperties(default(int), 2, 2, "B", 2);
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Tag>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			entity.SetProperties(default(int), 2, 2, "B", 2);
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Tag>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			entity.SetProperties(default(int), 2, 2, "B", 2);
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Tag>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>bceec0bd31e9e086bb4bec162e976159</Hash>
</Codenesium>*/