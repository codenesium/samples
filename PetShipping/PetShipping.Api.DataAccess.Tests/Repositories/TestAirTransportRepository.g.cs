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
			var records = await repository.All(1, 0, 1.ToString());

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
			entity.SetProperties(default(int), 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			var entity = new AirTransport();
			entity.SetProperties(default(int), 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			entity.SetProperties(default(int), 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

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
			entity.SetProperties(default(int), 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			entity.SetProperties(default(int), 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

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
    <Hash>f4fc33298172f90432ee8f5ad492c683</Hash>
</Codenesium>*/