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
	public partial class LocationRepositoryMoc
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

		public static Mock<ILogger<LocationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LocationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "Repositories")]
	public partial class LocationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			Location entity = new Location();
			entity.SetProperties(default(short), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LocationID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			var entity = new Location();
			entity.SetProperties(default(short), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<Location>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			entity.SetProperties(default(short), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LocationID);

			await repository.Update(record);

			var records = await context.Set<Location>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			entity.SetProperties(default(short), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Location>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			entity.SetProperties(default(short), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.LocationID);

			var records = await context.Set<Location>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(short));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>4cd75bd46134357bcf35cd701d5d3a73</Hash>
</Codenesium>*/