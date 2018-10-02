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
	public partial class TransactionStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TransactionStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "Repositories")]
	public partial class TransactionStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);

			TransactionStatu entity = new TransactionStatu();
			context.Set<TransactionStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);

			TransactionStatu entity = new TransactionStatu();
			context.Set<TransactionStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);

			var entity = new TransactionStatu();
			await repository.Create(entity);

			var record = await context.Set<TransactionStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);
			TransactionStatu entity = new TransactionStatu();
			context.Set<TransactionStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TransactionStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);
			TransactionStatu entity = new TransactionStatu();
			context.Set<TransactionStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TransactionStatu());

			var modifiedRecord = context.Set<TransactionStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TransactionStatuRepository>> loggerMoc = TransactionStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionStatuRepositoryMoc.GetContext();
			var repository = new TransactionStatuRepository(loggerMoc.Object, context);
			TransactionStatu entity = new TransactionStatu();
			context.Set<TransactionStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TransactionStatu modifiedRecord = await context.Set<TransactionStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0808b558da3b3d71d099391992fdf80b</Hash>
</Codenesium>*/