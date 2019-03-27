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

namespace CADNS.Api.DataAccess
{
	public partial class VehicleCapabilitiesRepositoryMoc
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

		public static Mock<ILogger<VehicleCapabilitiesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VehicleCapabilitiesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "Repositories")]
	public partial class VehicleCapabilitiesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);

			VehicleCapabilities entity = new VehicleCapabilities();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleCapabilities>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);

			var entity = new VehicleCapabilities();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<VehicleCapabilities>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);
			VehicleCapabilities entity = new VehicleCapabilities();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleCapabilities>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<VehicleCapabilities>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);
			VehicleCapabilities entity = new VehicleCapabilities();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleCapabilities>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<VehicleCapabilities>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);
			VehicleCapabilities entity = new VehicleCapabilities();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleCapabilities>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<VehicleCapabilities>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VehicleCapabilitiesRepository>> loggerMoc = VehicleCapabilitiesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilitiesRepositoryMoc.GetContext();
			var repository = new VehicleCapabilitiesRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0a0b9c5d150eeb5bdb637b8946f8bf50</Hash>
</Codenesium>*/