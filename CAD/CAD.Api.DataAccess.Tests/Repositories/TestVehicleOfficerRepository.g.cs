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
	public partial class VehicleOfficerRepositoryMoc
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

		public static Mock<ILogger<VehicleOfficerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VehicleOfficerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "Repositories")]
	public partial class VehicleOfficerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);

			VehicleOfficer entity = new VehicleOfficer();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleOfficer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);

			var entity = new VehicleOfficer();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<VehicleOfficer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);
			VehicleOfficer entity = new VehicleOfficer();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleOfficer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<VehicleOfficer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);
			VehicleOfficer entity = new VehicleOfficer();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleOfficer>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<VehicleOfficer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);
			VehicleOfficer entity = new VehicleOfficer();
			entity.SetProperties(default(int), 1, 1);
			context.Set<VehicleOfficer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<VehicleOfficer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VehicleOfficerRepository>> loggerMoc = VehicleOfficerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VehicleOfficerRepositoryMoc.GetContext();
			var repository = new VehicleOfficerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>980a40b3fdac25a5f73ab7077863e937</Hash>
</Codenesium>*/