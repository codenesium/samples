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
	public partial class TicketStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TicketStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TicketStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "Repositories")]
	public partial class TicketStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);

			TicketStatu entity = new TicketStatu();
			context.Set<TicketStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);

			TicketStatu entity = new TicketStatu();
			context.Set<TicketStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);

			var entity = new TicketStatu();
			await repository.Create(entity);

			var record = await context.Set<TicketStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);
			TicketStatu entity = new TicketStatu();
			context.Set<TicketStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TicketStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);
			TicketStatu entity = new TicketStatu();
			context.Set<TicketStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TicketStatu());

			var modifiedRecord = context.Set<TicketStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TicketStatuRepository>> loggerMoc = TicketStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatuRepositoryMoc.GetContext();
			var repository = new TicketStatuRepository(loggerMoc.Object, context);
			TicketStatu entity = new TicketStatu();
			context.Set<TicketStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TicketStatu modifiedRecord = await context.Set<TicketStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>42b37619bb3205b91139e11f9a1720da</Hash>
</Codenesium>*/