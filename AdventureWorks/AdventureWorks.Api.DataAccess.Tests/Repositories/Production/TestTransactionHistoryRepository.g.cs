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

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class TransactionHistoryRepositoryMoc
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

		public static Mock<ILogger<TransactionHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Repositories")]
	public partial class TransactionHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1m.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			TransactionHistory entity = new TransactionHistory();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			var entity = new TransactionHistory();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<TransactionHistory>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			await repository.Update(record);

			var records = await context.Set<TransactionHistory>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<TransactionHistory>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TransactionID);

			var records = await context.Set<TransactionHistory>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>f33b5280a6ca5fb69c0e9aac28b56bff</Hash>
</Codenesium>*/