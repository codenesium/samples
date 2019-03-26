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
	public partial class UnitMeasureRepositoryMoc
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

		public static Mock<ILogger<UnitMeasureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UnitMeasureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Repositories")]
	public partial class UnitMeasureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UnitMeasureCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			var entity = new UnitMeasure();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<UnitMeasure>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UnitMeasureCode);

			await repository.Update(record);

			var records = await context.Set<UnitMeasure>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<UnitMeasure>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			entity.SetProperties(default(string), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.UnitMeasureCode);

			var records = await context.Set<UnitMeasure>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a881dd31cebbfd0e56b9803eb1df5aea</Hash>
</Codenesium>*/