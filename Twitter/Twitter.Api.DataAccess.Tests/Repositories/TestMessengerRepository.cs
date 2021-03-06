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
	public partial class MessengerRepositoryMoc
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
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			Messenger entity = new Messenger();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
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
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<Messenger>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Messenger>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Messenger>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);
			Messenger entity = new Messenger();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			context.Set<Messenger>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Messenger>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<MessengerRepository>> loggerMoc = MessengerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MessengerRepositoryMoc.GetContext();
			var repository = new MessengerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>eed7939fe6b1b39eadf818b886250633</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/