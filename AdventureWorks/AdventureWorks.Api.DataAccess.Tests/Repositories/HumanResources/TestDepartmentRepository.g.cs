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
	public partial class DepartmentRepositoryMoc
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

		public static Mock<ILogger<DepartmentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DepartmentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Department")]
	[Trait("Area", "Repositories")]
	public partial class DepartmentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);

			Department entity = new Department();
			entity.SetProperties(default(short), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Department>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DepartmentID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);

			var entity = new Department();
			entity.SetProperties(default(short), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<Department>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);
			Department entity = new Department();
			entity.SetProperties(default(short), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Department>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DepartmentID);

			await repository.Update(record);

			var records = await context.Set<Department>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);
			Department entity = new Department();
			entity.SetProperties(default(short), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Department>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Department>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);
			Department entity = new Department();
			entity.SetProperties(default(short), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<Department>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.DepartmentID);

			var records = await context.Set<Department>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
			var repository = new DepartmentRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(short));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>f40c6f5c83ea0bef9c7a6890711db58f</Hash>
</Codenesium>*/