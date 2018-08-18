using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TransactionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TransactionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "Repositories")]
	public partial class TransactionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);

			Transaction entity = new Transaction();
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);

			Transaction entity = new Transaction();
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);

			var entity = new Transaction();
			await repository.Create(entity);

			var record = await context.Set<Transaction>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Transaction>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Transaction());

			var modifiedRecord = context.Set<Transaction>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Transaction modifiedRecord = await context.Set<Transaction>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>ba0888970340ff69f72ea470d1ba2272</Hash>
</Codenesium>*/