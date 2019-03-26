using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class MessageRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options, null);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
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
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);

			Message entity = new Message();
			entity.SetProperties(default(int), "B", 1);
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
			entity.SetProperties(default(int), "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Message>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.MessageId);

			await repository.Update(record);

			var records = await context.Set<Message>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Message>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);
			Message entity = new Message();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Message>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.MessageId);

			var records = await context.Set<Message>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<MessageRepository>> loggerMoc = MessageRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessageRepositoryMoc.GetContext();
			var repository = new MessageRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>73db6cc5f3b62df0c28e78bc4ad83151</Hash>
</Codenesium>*/