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

namespace PetStoreNS.Api.DataAccess
{
	public partial class BreedRepositoryMoc
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

		public static Mock<ILogger<BreedRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BreedRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "Repositories")]
	public partial class BreedRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			Breed entity = new Breed();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			var entity = new Breed();
			entity.SetProperties(default(int), "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Breed>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Breed>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Breed>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			entity.SetProperties(default(int), "B", 1);
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Breed>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>38dc1951ce82f8901e314f8330326676</Hash>
</Codenesium>*/