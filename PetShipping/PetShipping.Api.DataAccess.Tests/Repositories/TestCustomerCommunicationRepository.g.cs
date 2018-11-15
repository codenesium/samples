using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class CustomerCommunicationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CustomerCommunicationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CustomerCommunicationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "Repositories")]
	public partial class CustomerCommunicationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);

			CustomerCommunication entity = new CustomerCommunication();
			context.Set<CustomerCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);

			CustomerCommunication entity = new CustomerCommunication();
			context.Set<CustomerCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);

			var entity = new CustomerCommunication();
			await repository.Create(entity);

			var record = await context.Set<CustomerCommunication>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);
			CustomerCommunication entity = new CustomerCommunication();
			context.Set<CustomerCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<CustomerCommunication>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);
			CustomerCommunication entity = new CustomerCommunication();
			context.Set<CustomerCommunication>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CustomerCommunication());

			var modifiedRecord = context.Set<CustomerCommunication>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);
			CustomerCommunication entity = new CustomerCommunication();
			context.Set<CustomerCommunication>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			CustomerCommunication modifiedRecord = await context.Set<CustomerCommunication>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CustomerCommunicationRepository>> loggerMoc = CustomerCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerCommunicationRepositoryMoc.GetContext();
			var repository = new CustomerCommunicationRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d684f1c100cb00ca8d9c2ffe47587511</Hash>
</Codenesium>*/