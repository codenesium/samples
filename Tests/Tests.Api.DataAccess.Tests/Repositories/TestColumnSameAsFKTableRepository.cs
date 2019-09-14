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
	public partial class ColumnSameAsFKTableRepositoryMoc
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

		public static Mock<ILogger<ColumnSameAsFKTableRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ColumnSameAsFKTableRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Repositories")]
	public partial class ColumnSameAsFKTableRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(default(int), 1, 1);
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			var entity = new ColumnSameAsFKTable();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<ColumnSameAsFKTable>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(default(int), 1, 1);
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<ColumnSameAsFKTable>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(default(int), 1, 1);
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ColumnSameAsFKTable>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			entity.SetProperties(default(int), 1, 1);
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<ColumnSameAsFKTable>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>5d88fc5ee6a83f480a913dfa568379bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/