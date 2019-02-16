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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class AdminRepositoryMoc
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

		public static Mock<ILogger<AdminRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AdminRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Repositories")]
	public partial class AdminRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			Admin entity = new Admin();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			var entity = new Admin();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			await repository.Create(entity);

			var records = await context.Set<Admin>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Admin>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Admin>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Admin>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ba51842ef95894d65eccc4279d88616e</Hash>
</Codenesium>*/