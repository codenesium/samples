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

namespace PetShippingNS.Api.DataAccess
{
	public partial class OtherTransportRepositoryMoc
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

		public static Mock<ILogger<OtherTransportRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<OtherTransportRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Repositories")]
	public partial class OtherTransportRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 2, 1);
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			var entity = new OtherTransport();
			entity.SetProperties(1, 2, 1);
			await repository.Create(entity);

			var records = await context.Set<OtherTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 2, 1);
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<OtherTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 2, 1);
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<OtherTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 2, 1);
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<OtherTransport>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>669f5b77381d56c3a2425f71dce99b8f</Hash>
</Codenesium>*/