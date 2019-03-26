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
	public partial class SalesReasonRepositoryMoc
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

		public static Mock<ILogger<SalesReasonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesReasonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesReason")]
	[Trait("Area", "Repositories")]
	public partial class SalesReasonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);

			SalesReason entity = new SalesReason();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<SalesReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesReasonID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);

			var entity = new SalesReason();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			await repository.Create(entity);

			var records = await context.Set<SalesReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);
			SalesReason entity = new SalesReason();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<SalesReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesReasonID);

			await repository.Update(record);

			var records = await context.Set<SalesReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);
			SalesReason entity = new SalesReason();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<SalesReason>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SalesReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);
			SalesReason entity = new SalesReason();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			context.Set<SalesReason>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesReasonID);

			var records = await context.Set<SalesReason>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
			var repository = new SalesReasonRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>13c77e0bb3bcd940d06f8eb3c47a937d</Hash>
</Codenesium>*/