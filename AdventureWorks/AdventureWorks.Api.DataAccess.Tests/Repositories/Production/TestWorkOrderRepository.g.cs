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
	public partial class WorkOrderRepositoryMoc
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

		public static Mock<ILogger<WorkOrderRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<WorkOrderRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Repositories")]
	public partial class WorkOrderRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);

			WorkOrder entity = new WorkOrder();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<WorkOrder>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.WorkOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);

			var entity = new WorkOrder();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			await repository.Create(entity);

			var records = await context.Set<WorkOrder>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);
			WorkOrder entity = new WorkOrder();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<WorkOrder>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.WorkOrderID);

			await repository.Update(record);

			var records = await context.Set<WorkOrder>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);
			WorkOrder entity = new WorkOrder();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<WorkOrder>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<WorkOrder>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);
			WorkOrder entity = new WorkOrder();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<WorkOrder>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.WorkOrderID);

			var records = await context.Set<WorkOrder>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
			var repository = new WorkOrderRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>9b300b20e1fae3030f3ea3635fe5b4c7</Hash>
</Codenesium>*/