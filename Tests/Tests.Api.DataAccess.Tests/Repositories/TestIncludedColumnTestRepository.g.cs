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

namespace TestsNS.Api.DataAccess
{
	public partial class IncludedColumnTestRepositoryMoc
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

		public static Mock<ILogger<IncludedColumnTestRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<IncludedColumnTestRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Repositories")]
	public partial class IncludedColumnTestRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(default(int), "B", "B");
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			var entity = new IncludedColumnTest();
			entity.SetProperties(default(int), "B", "B");
			await repository.Create(entity);

			var records = await context.Set<IncludedColumnTest>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(default(int), "B", "B");
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<IncludedColumnTest>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(default(int), "B", "B");
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<IncludedColumnTest>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(default(int), "B", "B");
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<IncludedColumnTest>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a2a51a6da8111432b96dd903e272176a</Hash>
</Codenesium>*/