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
	public partial class SaleTicketRepositoryMoc
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

		public static Mock<ILogger<SaleTicketRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SaleTicketRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Repositories")]
	public partial class SaleTicketRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			SaleTicket entity = new SaleTicket();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			var entity = new SaleTicket();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<SaleTicket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<SaleTicket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SaleTicket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);
			SaleTicket entity = new SaleTicket();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTicket>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<SaleTicket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SaleTicketRepository>> loggerMoc = SaleTicketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketRepositoryMoc.GetContext();
			var repository = new SaleTicketRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>81ea52276762e2e208010997c8572c82</Hash>
</Codenesium>*/