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

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ShiftRepositoryMoc
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

		public static Mock<ILogger<ShiftRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ShiftRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "Repositories")]
	public partial class ShiftRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, TimeSpan.Parse("01:00:00").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			Shift entity = new Shift();
			entity.SetProperties(default(int), TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShiftID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			var entity = new Shift();
			entity.SetProperties(default(int), TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			await repository.Create(entity);

			var records = await context.Set<Shift>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			entity.SetProperties(default(int), TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShiftID);

			await repository.Update(record);

			var records = await context.Set<Shift>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			entity.SetProperties(default(int), TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Shift>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			entity.SetProperties(default(int), TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ShiftID);

			var records = await context.Set<Shift>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2bb2b3d3bdc7fc72d4de5e2467a2f81e</Hash>
</Codenesium>*/