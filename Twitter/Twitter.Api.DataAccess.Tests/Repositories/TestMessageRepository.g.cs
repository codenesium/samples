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
	public partial class MessageRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<MessageRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<MessageRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "Repositories")]
	public partial class MessageRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);

			Message entity = new Message();
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);

			Message entity = new Message();
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.MessageId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);

			var entity = new Message();
			await repository.Create(entity);

			var record = await context.Set<Message>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.MessageId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Message>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Message());

			var modifiedRecord = context.Set<Message>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.MessageId);

			Message modifiedRecord = await context.Set<Message>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>704bb90b495de260037b99f3f6dd050f</Hash>
</Codenesium>*/