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
	public partial class PasswordRepositoryMoc
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

		public static Mock<ILogger<PasswordRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PasswordRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Password")]
	[Trait("Area", "Repositories")]
	public partial class PasswordRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			Password entity = new Password();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			var entity = new Password();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<Password>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var records = await context.Set<Password>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Password>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			var records = await context.Set<Password>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>81f534d45d4dc69af90761ea96e2bef6</Hash>
</Codenesium>*/