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
	public partial class DestinationRepositoryMoc
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

		public static Mock<ILogger<DestinationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DestinationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "Repositories")]
	public partial class DestinationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			Destination entity = new Destination();
			entity.SetProperties(default(int), 1, "B", 2);
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			var entity = new Destination();
			entity.SetProperties(default(int), 1, "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Destination>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			entity.SetProperties(default(int), 1, "B", 2);
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Destination>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			entity.SetProperties(default(int), 1, "B", 2);
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Destination>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			entity.SetProperties(default(int), 1, "B", 2);
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Destination>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>f609a899c71e3f55743fc0b863ef4c4d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/