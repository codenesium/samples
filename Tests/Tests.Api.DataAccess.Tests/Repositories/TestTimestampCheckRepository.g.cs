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
	public partial class TimestampCheckRepositoryMoc
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

		public static Mock<ILogger<TimestampCheckRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TimestampCheckRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "Repositories")]
	public partial class TimestampCheckRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);

			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(2, "B", BitConverter.GetBytes(2));
			context.Set<TimestampCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);

			var entity = new TimestampCheck();
			entity.SetProperties(2, "B", BitConverter.GetBytes(2));
			await repository.Create(entity);

			var records = await context.Set<TimestampCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);
			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(2, "B", BitConverter.GetBytes(2));
			context.Set<TimestampCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<TimestampCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);
			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(2, "B", BitConverter.GetBytes(2));
			context.Set<TimestampCheck>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<TimestampCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);
			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(2, "B", BitConverter.GetBytes(2));
			context.Set<TimestampCheck>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<TimestampCheck>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
			var repository = new TimestampCheckRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>de806d92dff2846eef3d6a11392ada7e</Hash>
</Codenesium>*/