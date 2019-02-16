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
	public partial class AirTransportRepositoryMoc
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

		public static Mock<ILogger<AirTransportRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AirTransportRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Repositories")]
	public partial class AirTransportRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			AirTransport entity = new AirTransport();
			entity.SetProperties(default(int), "B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AirlineId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			var entity = new AirTransport();
			entity.SetProperties(default(int), "B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			await repository.Create(entity);

			var records = await context.Set<AirTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			entity.SetProperties(default(int), "B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AirlineId);

			await repository.Update(record);

			var records = await context.Set<AirTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			entity.SetProperties(default(int), "B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<AirTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			entity.SetProperties(default(int), "B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.AirlineId);

			var records = await context.Set<AirTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>8467c12c84eed34442b8f42004a1ff8b</Hash>
</Codenesium>*/