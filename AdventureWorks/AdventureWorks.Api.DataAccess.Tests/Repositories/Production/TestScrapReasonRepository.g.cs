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
	public partial class ScrapReasonRepositoryMoc
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

		public static Mock<ILogger<ScrapReasonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ScrapReasonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "Repositories")]
	public partial class ScrapReasonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			ScrapReason entity = new ScrapReason();
			entity.SetProperties(default(short), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ScrapReasonID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			var entity = new ScrapReason();
			entity.SetProperties(default(short), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<ScrapReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			entity.SetProperties(default(short), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ScrapReasonID);

			await repository.Update(record);

			var records = await context.Set<ScrapReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			entity.SetProperties(default(short), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ScrapReason>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			entity.SetProperties(default(short), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ScrapReasonID);

			var records = await context.Set<ScrapReason>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(short));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0ef34b5645dc2735cca72a8dc82fae4d</Hash>
</Codenesium>*/