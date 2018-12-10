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

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class StudioRepositoryMoc
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

		public static Mock<ILogger<StudioRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<StudioRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Repositories")]
	public partial class StudioRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);

			Studio entity = new Studio();
			entity.SetProperties("B", "B", "B", 2, "B", "B", "B", "B");
			context.Set<Studio>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);

			var entity = new Studio();
			entity.SetProperties("B", "B", "B", 2, "B", "B", "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Studio>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);
			Studio entity = new Studio();
			entity.SetProperties("B", "B", "B", 2, "B", "B", "B", "B");
			context.Set<Studio>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Studio>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);
			Studio entity = new Studio();
			entity.SetProperties("B", "B", "B", 2, "B", "B", "B", "B");
			context.Set<Studio>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Studio>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);
			Studio entity = new Studio();
			entity.SetProperties("B", "B", "B", 2, "B", "B", "B", "B");
			context.Set<Studio>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Studio>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudioRepositoryMoc.GetContext();
			var repository = new StudioRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>f9e990915ab61bfabf933b0c9c427b1a</Hash>
</Codenesium>*/