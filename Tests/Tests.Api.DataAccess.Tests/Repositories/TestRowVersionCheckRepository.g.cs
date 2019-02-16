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
	public partial class RowVersionCheckRepositoryMoc
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

		public static Mock<ILogger<RowVersionCheckRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RowVersionCheckRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Repositories")]
	public partial class RowVersionCheckRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			RowVersionCheck entity = new RowVersionCheck();
			entity.SetProperties(default(int), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			var entity = new RowVersionCheck();
			entity.SetProperties(default(int), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<RowVersionCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			entity.SetProperties(default(int), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<RowVersionCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			entity.SetProperties(default(int), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<RowVersionCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			entity.SetProperties(default(int), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<RowVersionCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a6b319abe51ca84fadbc488eb6f14bc7</Hash>
</Codenesium>*/