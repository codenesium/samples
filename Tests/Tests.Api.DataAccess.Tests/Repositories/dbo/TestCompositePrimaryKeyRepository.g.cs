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

namespace TestsNS.Api.DataAccess
{
	public partial class CompositePrimaryKeyRepositoryMoc
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

		public static Mock<ILogger<CompositePrimaryKeyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CompositePrimaryKeyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Repositories")]
	public partial class CompositePrimaryKeyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(2, 2);
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			var entity = new CompositePrimaryKey();
			entity.SetProperties(2, 2);
			await repository.Create(entity);

			var records = await context.Set<CompositePrimaryKey>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(2, 2);
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<CompositePrimaryKey>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(2, 2);
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<CompositePrimaryKey>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			entity.SetProperties(2, 2);
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<CompositePrimaryKey>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e357f44d8a8846aee26624a9fa70800a</Hash>
</Codenesium>*/