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
	public partial class BillOfMaterialRepositoryMoc
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

		public static Mock<ILogger<BillOfMaterialRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BillOfMaterialRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "Repositories")]
	public partial class BillOfMaterialRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

			BillOfMaterial entity = new BillOfMaterial();
			entity.SetProperties(default(int), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<BillOfMaterial>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BillOfMaterialsID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

			var entity = new BillOfMaterial();
			entity.SetProperties(default(int), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			await repository.Create(entity);

			var records = await context.Set<BillOfMaterial>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
			BillOfMaterial entity = new BillOfMaterial();
			entity.SetProperties(default(int), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<BillOfMaterial>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BillOfMaterialsID);

			await repository.Update(record);

			var records = await context.Set<BillOfMaterial>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
			BillOfMaterial entity = new BillOfMaterial();
			entity.SetProperties(default(int), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<BillOfMaterial>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<BillOfMaterial>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
			BillOfMaterial entity = new BillOfMaterial();
			entity.SetProperties(default(int), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<BillOfMaterial>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BillOfMaterialsID);

			var records = await context.Set<BillOfMaterial>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
			var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d92b5ff3fb301162757329fac43cbf7e</Hash>
</Codenesium>*/