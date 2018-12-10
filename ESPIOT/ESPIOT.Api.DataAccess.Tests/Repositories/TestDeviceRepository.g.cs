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

namespace ESPIOTNS.Api.DataAccess
{
	public partial class DeviceRepositoryMoc
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

		public static Mock<ILogger<DeviceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DeviceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "Repositories")]
	public partial class DeviceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			Device entity = new Device();
			entity.SetProperties(2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			var entity = new Device();
			entity.SetProperties(2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<Device>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			entity.SetProperties(2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Device>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			entity.SetProperties(2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Device>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			entity.SetProperties(2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Device>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>cb03fff074696bcbebcfd4e51ae3bb71</Hash>
</Codenesium>*/