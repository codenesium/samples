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

namespace PetShippingNS.Api.DataAccess
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
			var context = new ApplicationDbContext(options.Options);
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
			var records = await repository.All(1, 0, "A".ToString());

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
			entity.SetProperties(default(int), "B", true, true, "B");
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);

			var entity = new Employee();
			entity.SetProperties(default(int), "B", true, true, "B");
			await repository.Create(entity);

			var records = await context.Set<Employee>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), "B", true, true, "B");
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Employee>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), "B", true, true, "B");
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Employee>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
			var repository = new EmployeeRepository(loggerMoc.Object, context);
			Employee entity = new Employee();
			entity.SetProperties(default(int), "B", true, true, "B");
			context.Set<Employee>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Employee>().Where(x => true).ToListAsync();

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
    <Hash>907bb13718aa74b7a0524e8ca20ee571</Hash>
</Codenesium>*/