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

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class IllustrationRepositoryMoc
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

		public static Mock<ILogger<IllustrationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<IllustrationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Illustration")]
	[Trait("Area", "Repositories")]
	public partial class IllustrationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			Illustration entity = new Illustration();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.IllustrationID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			var entity = new Illustration();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			await repository.Create(entity);

			var records = await context.Set<Illustration>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.IllustrationID);

			await repository.Update(record);

			var records = await context.Set<Illustration>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Illustration>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.IllustrationID);

			var records = await context.Set<Illustration>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>071c8728cf2f3fc8b045a65ea8e7aac8</Hash>
</Codenesium>*/