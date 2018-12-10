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

namespace StackOverflowNS.Api.DataAccess
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
			entity.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			var entity = new User();
			entity.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
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
			entity.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

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
			entity.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
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
			entity.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

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
    <Hash>cbf75d6edfacd0d638976d491b2915a2</Hash>
</Codenesium>*/