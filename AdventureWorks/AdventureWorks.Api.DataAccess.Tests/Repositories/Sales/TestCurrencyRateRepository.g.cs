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
	public partial class CurrencyRateRepositoryMoc
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

		public static Mock<ILogger<CurrencyRateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CurrencyRateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Repositories")]
	public partial class CurrencyRateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyRateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			var entity = new CurrencyRate();
			entity.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			await repository.Create(entity);

			var records = await context.Set<CurrencyRate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyRateID);

			await repository.Update(record);

			var records = await context.Set<CurrencyRate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<CurrencyRate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			entity.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CurrencyRateID);

			var records = await context.Set<CurrencyRate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>dbd087179202e4ccc55b53895ec869e2</Hash>
</Codenesium>*/