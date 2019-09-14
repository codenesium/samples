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
	public partial class PetRepositoryMoc
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

		public static Mock<ILogger<PetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "Repositories")]
	public partial class PetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			Pet entity = new Pet();
			entity.SetProperties(default(int), 1, 2, "B", 2);
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			var entity = new Pet();
			entity.SetProperties(default(int), 1, 2, "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Pet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			entity.SetProperties(default(int), 1, 2, "B", 2);
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Pet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			entity.SetProperties(default(int), 1, 2, "B", 2);
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Pet>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			entity.SetProperties(default(int), 1, 2, "B", 2);
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Pet>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>1bd6c383db8da4a1c2afd8e3b7900e99</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/