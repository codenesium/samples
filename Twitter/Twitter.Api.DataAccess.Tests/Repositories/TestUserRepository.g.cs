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

namespace TwitterNS.Api.DataAccess
{
	public partial class UserRepositoryMoc
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

		public static Mock<ILogger<UserRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UserRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "Repositories")]
	public partial class UserRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			User entity = new User();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", 2, "B", "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			var entity = new User();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", 2, "B", "B");
			await repository.Create(entity);

			var records = await context.Set<User>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", 2, "B", "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			await repository.Update(record);

			var records = await context.Set<User>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", 2, "B", "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<User>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			entity.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", 2, "B", "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.UserId);

			var records = await context.Set<User>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>5b8a7327102df0683b69574efa5d4e9d</Hash>
</Codenesium>*/