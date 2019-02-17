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

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class FamilyRepositoryMoc
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

		public static Mock<ILogger<FamilyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FamilyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "Repositories")]
	public partial class FamilyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			Family entity = new Family();
			entity.SetProperties(default(int), "B", "B", "B", "B", "B");
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			var entity = new Family();
			entity.SetProperties(default(int), "B", "B", "B", "B", "B");
			await repository.Create(entity);

			var records = await context.Set<Family>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			entity.SetProperties(default(int), "B", "B", "B", "B", "B");
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Family>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			entity.SetProperties(default(int), "B", "B", "B", "B", "B");
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Family>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			entity.SetProperties(default(int), "B", "B", "B", "B", "B");
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Family>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2024fcafabb8af0d794d0bb6ef957cd6</Hash>
</Codenesium>*/