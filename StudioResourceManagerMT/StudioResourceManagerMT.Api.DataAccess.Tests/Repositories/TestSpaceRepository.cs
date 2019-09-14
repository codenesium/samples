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
	public partial class SpaceRepositoryMoc
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

		public static Mock<ILogger<SpaceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpaceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "Repositories")]
	public partial class SpaceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			Space entity = new Space();
			entity.SetProperties(default(int), "B", "B");
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			var entity = new Space();
			entity.SetProperties(default(int), "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Space>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			entity.SetProperties(default(int), "B", "B");
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Space>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			entity.SetProperties(default(int), "B", "B");
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Space>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			entity.SetProperties(default(int), "B", "B");
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Space>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>df2faed1d247027d74ecc2df6a8e762a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/