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
	public partial class SpaceSpaceFeatureRepositoryMoc
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

		public static Mock<ILogger<SpaceSpaceFeatureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpaceSpaceFeatureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Repositories")]
	public partial class SpaceSpaceFeatureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			var entity = new SpaceSpaceFeature();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<SpaceSpaceFeature>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<SpaceSpaceFeature>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SpaceSpaceFeature>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<SpaceSpaceFeature>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>109e0679a6dd8cf6d382940efbe9d819</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/