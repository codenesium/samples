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
	public partial class VersionInfoRepositoryMoc
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

		public static Mock<ILogger<VersionInfoRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VersionInfoRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Repositories")]
	public partial class VersionInfoRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			VersionInfo entity = new VersionInfo();
			entity.SetProperties(default(long), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Version);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			var entity = new VersionInfo();
			entity.SetProperties(default(long), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<VersionInfo>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			entity.SetProperties(default(long), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Version);

			await repository.Update(record);

			var records = await context.Set<VersionInfo>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			entity.SetProperties(default(long), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<VersionInfo>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			entity.SetProperties(default(long), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Version);

			var records = await context.Set<VersionInfo>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(long));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c5d2150737d6eac8e142572ec528fbe7</Hash>
</Codenesium>*/