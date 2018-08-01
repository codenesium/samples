using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetStoreNS.Api.DataAccess
{
	public partial class PaymentTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PaymentTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PaymentTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "Repositories")]
	public partial class PaymentTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);

			PaymentType entity = new PaymentType();
			context.Set<PaymentType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);

			PaymentType entity = new PaymentType();
			context.Set<PaymentType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);

			var entity = new PaymentType();
			await repository.Create(entity);

			var record = await context.Set<PaymentType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);
			PaymentType entity = new PaymentType();
			context.Set<PaymentType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PaymentType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);
			PaymentType entity = new PaymentType();
			context.Set<PaymentType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PaymentType());

			var modifiedRecord = context.Set<PaymentType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PaymentTypeRepository>> loggerMoc = PaymentTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PaymentTypeRepositoryMoc.GetContext();
			var repository = new PaymentTypeRepository(loggerMoc.Object, context);
			PaymentType entity = new PaymentType();
			context.Set<PaymentType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PaymentType modifiedRecord = await context.Set<PaymentType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>276451488b164ab7a6986da876a633c2</Hash>
</Codenesium>*/