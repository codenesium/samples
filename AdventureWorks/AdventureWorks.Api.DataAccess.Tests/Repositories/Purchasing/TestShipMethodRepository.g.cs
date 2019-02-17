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
	public partial class ShipMethodRepositoryMoc
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

		public static Mock<ILogger<ShipMethodRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ShipMethodRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "Repositories")]
	public partial class ShipMethodRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);

			ShipMethod entity = new ShipMethod();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<ShipMethod>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShipMethodID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);

			var entity = new ShipMethod();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			await repository.Create(entity);

			var records = await context.Set<ShipMethod>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);
			ShipMethod entity = new ShipMethod();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<ShipMethod>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShipMethodID);

			await repository.Update(record);

			var records = await context.Set<ShipMethod>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);
			ShipMethod entity = new ShipMethod();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<ShipMethod>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ShipMethod>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);
			ShipMethod entity = new ShipMethod();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			context.Set<ShipMethod>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ShipMethodID);

			var records = await context.Set<ShipMethod>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
			var repository = new ShipMethodRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>72a94c943d8f4be5e48a8af3f68c5e1d</Hash>
</Codenesium>*/