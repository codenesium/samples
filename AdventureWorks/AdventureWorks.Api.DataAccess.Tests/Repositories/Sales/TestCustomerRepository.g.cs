using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class CustomerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			Customer entity = new Customer();
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
			await repository.Create(entity);

			var record = await context.Set<Customer>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CustomerID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Customer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Customer());

			var modifiedRecord = context.Set<Customer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CustomerID);

			Customer modifiedRecord = await context.Set<Customer>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
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
    <Hash>4612faa0cf366ac6c1d4ade4795f45ec</Hash>
</Codenesium>*/