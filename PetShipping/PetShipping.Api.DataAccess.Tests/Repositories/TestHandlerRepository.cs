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
	public partial class HandlerRepositoryMoc
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

		public static Mock<ILogger<HandlerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<HandlerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "Repositories")]
	public partial class HandlerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			Handler entity = new Handler();
			entity.SetProperties(default(int), 2, "B", "B", "B", "B");
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			var entity = new Handler();
			entity.SetProperties(default(int), 2, "B", "B", "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Handler>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			entity.SetProperties(default(int), 2, "B", "B", "B", "B");
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Handler>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			entity.SetProperties(default(int), 2, "B", "B", "B", "B");
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Handler>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			entity.SetProperties(default(int), 2, "B", "B", "B", "B");
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Handler>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>92014feaece1400e3545bc6c60a0ac0e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/