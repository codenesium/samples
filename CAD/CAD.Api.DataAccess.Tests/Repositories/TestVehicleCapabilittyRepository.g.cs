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
	public partial class VehicleCapabilittyRepositoryMoc
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

		public static Mock<ILogger<VehicleCapabilittyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VehicleCapabilittyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "Repositories")]
	public partial class VehicleCapabilittyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);

			VehicleCapabilitty entity = new VehicleCapabilitty();
			entity.SetProperties(default(int), 1);
			context.Set<VehicleCapabilitty>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.VehicleId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);

			var entity = new VehicleCapabilitty();
			entity.SetProperties(default(int), 1);
			await repository.Create(entity);

			var records = await context.Set<VehicleCapabilitty>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);
			VehicleCapabilitty entity = new VehicleCapabilitty();
			entity.SetProperties(default(int), 1);
			context.Set<VehicleCapabilitty>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.VehicleId);

			await repository.Update(record);

			var records = await context.Set<VehicleCapabilitty>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);
			VehicleCapabilitty entity = new VehicleCapabilitty();
			entity.SetProperties(default(int), 1);
			context.Set<VehicleCapabilitty>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<VehicleCapabilitty>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);
			VehicleCapabilitty entity = new VehicleCapabilitty();
			entity.SetProperties(default(int), 1);
			context.Set<VehicleCapabilitty>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.VehicleId);

			var records = await context.Set<VehicleCapabilitty>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VehicleCapabilittyRepository>> loggerMoc = VehicleCapabilittyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleCapabilittyRepositoryMoc.GetContext();
			var repository = new VehicleCapabilittyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2b01508c454723ae9a0a63e575336030</Hash>
</Codenesium>*/