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
	public partial class CreditCardRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CreditCardRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CreditCardRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Repositories")]
	public partial class CreditCardRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			CreditCard entity = new CreditCard();
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			CreditCard entity = new CreditCard();
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CreditCardID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			var entity = new CreditCard();
			await repository.Create(entity);

			var record = await context.Set<CreditCard>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CreditCardID);

			await repository.Update(record);

			var modifiedRecord = context.Set<CreditCard>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CreditCard());

			var modifiedRecord = context.Set<CreditCard>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CreditCardID);

			CreditCard modifiedRecord = await context.Set<CreditCard>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2b339424b868c2e6fae87ffbae548f53</Hash>
</Codenesium>*/