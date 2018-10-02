using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class MessengerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<MessengerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<MessengerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "Repositories")]
	public partial class MessengerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			Messenger entity = new Messenger();
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			Messenger entity = new Messenger();
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			var entity = new Messenger();
			await repository.Create(entity);

			var record = await context.Set<Messenger>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Messenger>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Messenger());

			var modifiedRecord = context.Set<Messenger>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Messenger modifiedRecord = await context.Set<Messenger>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>5d65d5ea7d5de1ef152e35dffd53e4d3</Hash>
</Codenesium>*/