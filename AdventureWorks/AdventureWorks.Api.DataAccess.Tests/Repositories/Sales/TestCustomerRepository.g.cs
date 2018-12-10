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
			entity.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CustomerID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			var entity = new Customer();
			entity.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
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
			entity.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CustomerID);

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
			entity.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
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
			entity.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CustomerID);

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
    <Hash>8e7201669094f19e54ce5f52a8d41ec9</Hash>
</Codenesium>*/