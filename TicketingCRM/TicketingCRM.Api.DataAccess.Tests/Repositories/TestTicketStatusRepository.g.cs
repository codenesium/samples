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

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TicketStatusRepositoryMoc
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

		public static Mock<ILogger<TicketStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TicketStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "Repositories")]
	public partial class TicketStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);

			TicketStatus entity = new TicketStatus();
			entity.SetProperties(default(int), "B");
			context.Set<TicketStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);

			var entity = new TicketStatus();
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<TicketStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);
			TicketStatus entity = new TicketStatus();
			entity.SetProperties(default(int), "B");
			context.Set<TicketStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<TicketStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);
			TicketStatus entity = new TicketStatus();
			entity.SetProperties(default(int), "B");
			context.Set<TicketStatus>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<TicketStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);
			TicketStatus entity = new TicketStatus();
			entity.SetProperties(default(int), "B");
			context.Set<TicketStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<TicketStatus>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
			var repository = new TicketStatusRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e54bdeb1ee473a25d60c2209adf63ffd</Hash>
</Codenesium>*/