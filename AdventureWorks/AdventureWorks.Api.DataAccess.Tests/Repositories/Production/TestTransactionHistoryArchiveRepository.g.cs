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
	public partial class TransactionHistoryArchiveRepositoryMoc
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

		public static Mock<ILogger<TransactionHistoryArchiveRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionHistoryArchiveRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Repositories")]
	public partial class TransactionHistoryArchiveRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			var entity = new TransactionHistoryArchive();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<TransactionHistoryArchive>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			await repository.Update(record);

			var records = await context.Set<TransactionHistoryArchive>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<TransactionHistoryArchive>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			entity.SetProperties(default(int), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TransactionID);

			var records = await context.Set<TransactionHistoryArchive>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>554ee0ce35826c0b647f5aae7c111f6d</Hash>
</Codenesium>*/