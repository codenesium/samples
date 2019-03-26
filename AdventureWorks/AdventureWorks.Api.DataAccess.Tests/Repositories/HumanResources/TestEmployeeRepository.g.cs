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
	public partial class EmployeeRepositoryMoc
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

		public static Mock<ILogger<EmployeeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EmployeeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "Repositories")]
	public partial class EmployeeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);

			Employee entity = new Employee();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);

			var entity = new Employee();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			await repository.Create(entity);

			var records = await context.Set<Employee>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var records = await context.Set<Employee>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Employee>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			var records = await context.Set<Employee>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>df82e4f346b260fb32043d32b1107e4a</Hash>
</Codenesium>*/