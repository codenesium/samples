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

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TransactionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
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
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1m.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);

			Transaction entity = new Transaction();
			entity.SetProperties(default(int), 2m, "B", 1);
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
			entity.SetProperties(default(int), 2m, "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Transaction>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			entity.SetProperties(default(int), 2m, "B", 1);
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Transaction>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			entity.SetProperties(default(int), 2m, "B", 1);
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Transaction>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);
			Transaction entity = new Transaction();
			entity.SetProperties(default(int), 2m, "B", 1);
			context.Set<Transaction>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Transaction>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TransactionRepository>> loggerMoc = TransactionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionRepositoryMoc.GetContext();
			var repository = new TransactionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>861f5c98b7cbfed77ae194e5758f24a0</Hash>
</Codenesium>*/