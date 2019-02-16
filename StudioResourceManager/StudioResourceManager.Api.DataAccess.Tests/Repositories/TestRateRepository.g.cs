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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class RateRepositoryMoc
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

		public static Mock<ILogger<RateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "Repositories")]
	public partial class RateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1m.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			Rate entity = new Rate();
			entity.SetProperties(default(int), 2m, 1, 1);
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			var entity = new Rate();
			entity.SetProperties(default(int), 2m, 1, 1);
			await repository.Create(entity);

			var records = await context.Set<Rate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			entity.SetProperties(default(int), 2m, 1, 1);
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Rate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			entity.SetProperties(default(int), 2m, 1, 1);
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Rate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			entity.SetProperties(default(int), 2m, 1, 1);
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Rate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>22f256f6423db359f72fb311565ee15b</Hash>
</Codenesium>*/