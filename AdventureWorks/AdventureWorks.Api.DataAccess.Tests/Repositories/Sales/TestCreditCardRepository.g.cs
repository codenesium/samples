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
	public partial class CreditCardRepositoryMoc
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

		public static Mock<ILogger<CreditCardRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CreditCardRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Repositories")]
	public partial class CreditCardRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			CreditCard entity = new CreditCard();
			entity.SetProperties("B", "B", 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CreditCardID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			var entity = new CreditCard();
			entity.SetProperties("B", "B", 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			await repository.Create(entity);

			var records = await context.Set<CreditCard>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			entity.SetProperties("B", "B", 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CreditCardID);

			await repository.Update(record);

			var records = await context.Set<CreditCard>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			entity.SetProperties("B", "B", 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<CreditCard>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);
			CreditCard entity = new CreditCard();
			entity.SetProperties("B", "B", 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CreditCard>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CreditCardID);

			var records = await context.Set<CreditCard>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CreditCardRepository>> loggerMoc = CreditCardRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CreditCardRepositoryMoc.GetContext();
			var repository = new CreditCardRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>473d7a07c1b9f0700ec8f29b6d33b271</Hash>
</Codenesium>*/