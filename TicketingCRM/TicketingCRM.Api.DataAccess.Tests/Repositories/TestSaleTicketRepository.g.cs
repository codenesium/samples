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
	public partial class SaleTicketRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SaleTicketRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SaleTicketRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Repositories")]
	public partial class SaleTicketRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			SaleTicket entity = new SaleTicket();
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			SaleTicket entity = new SaleTicket();
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			var entity = new SaleTicket();
			await repository.Create(entity);

			var record = await context.Set<SaleTicket>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SaleTicket>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SaleTicket());

			var modifiedRecord = context.Set<SaleTicket>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SaleTicket modifiedRecord = await context.Set<SaleTicket>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>4b7179f3c731fe5a7d88d6502f3e7ed1</Hash>
</Codenesium>*/