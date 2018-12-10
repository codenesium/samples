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

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainRepositoryMoc
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

		public static Mock<ILogger<ChainRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ChainRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Chain")]
	[Trait("Area", "Repositories")]
	public partial class ChainRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);

			Chain entity = new Chain();
			entity.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B", 1);
			context.Set<Chain>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);

			var entity = new Chain();
			entity.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Chain>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);
			Chain entity = new Chain();
			entity.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B", 1);
			context.Set<Chain>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Chain>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);
			Chain entity = new Chain();
			entity.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B", 1);
			context.Set<Chain>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Chain>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);
			Chain entity = new Chain();
			entity.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B", 1);
			context.Set<Chain>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Chain>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainRepositoryMoc.GetContext();
			var repository = new ChainRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2a86eb05ca17d34409c3e42d87c86f81</Hash>
</Codenesium>*/