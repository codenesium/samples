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
	public partial class PurchaseOrderHeaderRepositoryMoc
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

		public static Mock<ILogger<PurchaseOrderHeaderRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PurchaseOrderHeaderRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Repositories")]
	public partial class PurchaseOrderHeaderRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

			PurchaseOrderHeader entity = new PurchaseOrderHeader();
			entity.SetProperties(default(int), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			context.Set<PurchaseOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PurchaseOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

			var entity = new PurchaseOrderHeader();
			entity.SetProperties(default(int), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			await repository.Create(entity);

			var records = await context.Set<PurchaseOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);
			PurchaseOrderHeader entity = new PurchaseOrderHeader();
			entity.SetProperties(default(int), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			context.Set<PurchaseOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PurchaseOrderID);

			await repository.Update(record);

			var records = await context.Set<PurchaseOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);
			PurchaseOrderHeader entity = new PurchaseOrderHeader();
			entity.SetProperties(default(int), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			context.Set<PurchaseOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<PurchaseOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);
			PurchaseOrderHeader entity = new PurchaseOrderHeader();
			entity.SetProperties(default(int), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			context.Set<PurchaseOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.PurchaseOrderID);

			var records = await context.Set<PurchaseOrderHeader>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
			var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0e5db866b277659b7acc67b1133b09c2</Hash>
</Codenesium>*/