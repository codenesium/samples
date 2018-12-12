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

namespace ESPIOTNS.Api.DataAccess
{
	public partial class EfmigrationshistoryRepositoryMoc
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

		public static Mock<ILogger<EfmigrationshistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EfmigrationshistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "Repositories")]
	public partial class EfmigrationshistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);

			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("B", "B");
			context.Set<Efmigrationshistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.MigrationId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);

			var entity = new Efmigrationshistory();
			entity.SetProperties("B", "B");
			await repository.Create(entity);

			var records = await context.Set<Efmigrationshistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);
			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("B", "B");
			context.Set<Efmigrationshistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.MigrationId);

			await repository.Update(record);

			var records = await context.Set<Efmigrationshistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);
			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("B", "B");
			context.Set<Efmigrationshistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Efmigrationshistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);
			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("B", "B");
			context.Set<Efmigrationshistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.MigrationId);

			var records = await context.Set<Efmigrationshistory>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<EfmigrationshistoryRepository>> loggerMoc = EfmigrationshistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EfmigrationshistoryRepositoryMoc.GetContext();
			var repository = new EfmigrationshistoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c7ad4e1012899902a38a1dfd034d2fad</Hash>
</Codenesium>*/