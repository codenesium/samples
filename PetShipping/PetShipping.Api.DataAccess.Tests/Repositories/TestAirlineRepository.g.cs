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

namespace PetShippingNS.Api.DataAccess
{
	public partial class AirlineRepositoryMoc
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

		public static Mock<ILogger<AirlineRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AirlineRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "Repositories")]
	public partial class AirlineRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			Airline entity = new Airline();
			entity.SetProperties(default(int), "B");
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			var entity = new Airline();
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<Airline>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			entity.SetProperties(default(int), "B");
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Airline>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			entity.SetProperties(default(int), "B");
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Airline>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			entity.SetProperties(default(int), "B");
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Airline>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>8c5fd1d3d36a64696f4fd5eaeb83c42f</Hash>
</Codenesium>*/