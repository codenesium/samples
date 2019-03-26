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
	public partial class TagsRepositoryMoc
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

		public static Mock<ILogger<TagsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TagsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tags")]
	[Trait("Area", "Repositories")]
	public partial class TagsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);

			Tags entity = new Tags();
			entity.SetProperties(default(int), 2, 1, "B", 1);
			context.Set<Tags>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);

			var entity = new Tags();
			entity.SetProperties(default(int), 2, 1, "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Tags>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);
			Tags entity = new Tags();
			entity.SetProperties(default(int), 2, 1, "B", 1);
			context.Set<Tags>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Tags>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);
			Tags entity = new Tags();
			entity.SetProperties(default(int), 2, 1, "B", 1);
			context.Set<Tags>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Tags>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);
			Tags entity = new Tags();
			entity.SetProperties(default(int), 2, 1, "B", 1);
			context.Set<Tags>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Tags>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagsRepositoryMoc.GetContext();
			var repository = new TagsRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>daf3397a4d4ad286950e794437ae8f2d</Hash>
</Codenesium>*/