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
	public partial class SaleTicketsRepositoryMoc
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

		public static Mock<ILogger<SaleTicketsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SaleTicketsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "Repositories")]
	public partial class SaleTicketsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);

			SaleTickets entity = new SaleTickets();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTickets>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);

			var entity = new SaleTickets();
			entity.SetProperties(default(int), 1, 1);
			await repository.Create(entity);

			var records = await context.Set<SaleTickets>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);
			SaleTickets entity = new SaleTickets();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTickets>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<SaleTickets>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);
			SaleTickets entity = new SaleTickets();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTickets>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SaleTickets>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);
			SaleTickets entity = new SaleTickets();
			entity.SetProperties(default(int), 1, 1);
			context.Set<SaleTickets>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<SaleTickets>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
			var repository = new SaleTicketsRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>03055e955b1f0d9cad213489649a9b29</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/