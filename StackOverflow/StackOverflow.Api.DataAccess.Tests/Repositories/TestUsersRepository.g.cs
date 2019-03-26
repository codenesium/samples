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
	public partial class UsersRepositoryMoc
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

		public static Mock<ILogger<UsersRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UsersRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Users")]
	[Trait("Area", "Repositories")]
	public partial class UsersRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);

			Users entity = new Users();
			entity.SetProperties(default(int), "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<Users>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);

			var entity = new Users();
			entity.SetProperties(default(int), "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			await repository.Create(entity);

			var records = await context.Set<Users>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);
			Users entity = new Users();
			entity.SetProperties(default(int), "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<Users>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Users>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);
			Users entity = new Users();
			entity.SetProperties(default(int), "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<Users>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Users>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);
			Users entity = new Users();
			entity.SetProperties(default(int), "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			context.Set<Users>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Users>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UsersRepositoryMoc.GetContext();
			var repository = new UsersRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>5354e9c4c3f4c032b6f8c472f1a84512</Hash>
</Codenesium>*/