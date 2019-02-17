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
	public partial class CountryRegionRepositoryMoc
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

		public static Mock<ILogger<CountryRegionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CountryRegionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "Repositories")]
	public partial class CountryRegionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			CountryRegion entity = new CountryRegion();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			var entity = new CountryRegion();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<CountryRegion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			await repository.Update(record);

			var records = await context.Set<CountryRegion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<CountryRegion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CountryRegionCode);

			var records = await context.Set<CountryRegion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a214b20246c82e207785e135d765db77</Hash>
</Codenesium>*/