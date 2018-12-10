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

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class CustomerRepositoryMoc
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

		public static Mock<ILogger<CustomerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CustomerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "Repositories")]
	public partial class CustomerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			Customer entity = new Customer();
			entity.SetProperties("B", "B", 2, "B", "B");
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			var entity = new Customer();
			entity.SetProperties("B", "B", 2, "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Customer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			entity.SetProperties("B", "B", 2, "B", "B");
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Customer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			entity.SetProperties("B", "B", 2, "B", "B");
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Customer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			entity.SetProperties("B", "B", 2, "B", "B");
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Customer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>b3dd739ec096563f5c0488c785540cc8</Hash>
</Codenesium>*/