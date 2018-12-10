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
	public partial class TeamRepositoryMoc
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

		public static Mock<ILogger<TeamRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TeamRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "Repositories")]
	public partial class TeamRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			Team entity = new Team();
			entity.SetProperties(2, "B", 1);
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			var entity = new Team();
			entity.SetProperties(2, "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Team>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			entity.SetProperties(2, "B", 1);
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Team>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			entity.SetProperties(2, "B", 1);
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Team>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			entity.SetProperties(2, "B", 1);
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Team>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e8b436a4c009cc6d4591fe87ab92bd96</Hash>
</Codenesium>*/