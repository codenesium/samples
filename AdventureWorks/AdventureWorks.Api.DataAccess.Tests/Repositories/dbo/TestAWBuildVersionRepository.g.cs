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
	public partial class AWBuildVersionRepositoryMoc
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

		public static Mock<ILogger<AWBuildVersionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AWBuildVersionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Repositories")]
	public partial class AWBuildVersionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

			AWBuildVersion entity = new AWBuildVersion();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SystemInformationID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

			var entity = new AWBuildVersion();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			await repository.Create(entity);

			var records = await context.Set<AWBuildVersion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
			AWBuildVersion entity = new AWBuildVersion();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SystemInformationID);

			await repository.Update(record);

			var records = await context.Set<AWBuildVersion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
			AWBuildVersion entity = new AWBuildVersion();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<AWBuildVersion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
			AWBuildVersion entity = new AWBuildVersion();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SystemInformationID);

			var records = await context.Set<AWBuildVersion>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
			var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>b4d36c37d66f3c26a953441d543abebe</Hash>
</Codenesium>*/