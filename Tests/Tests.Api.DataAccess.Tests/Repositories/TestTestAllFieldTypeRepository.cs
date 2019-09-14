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
	public partial class TestAllFieldTypeRepositoryMoc
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

		public static Mock<ILogger<TestAllFieldTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TestAllFieldTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Repositories")]
	public partial class TestAllFieldTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			TestAllFieldType entity = new TestAllFieldType();
			entity.SetProperties(default(int), 2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			var entity = new TestAllFieldType();
			entity.SetProperties(default(int), 2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			await repository.Create(entity);

			var records = await context.Set<TestAllFieldType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			entity.SetProperties(default(int), 2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<TestAllFieldType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			entity.SetProperties(default(int), 2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<TestAllFieldType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			entity.SetProperties(default(int), 2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2m, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("02:00:00"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<TestAllFieldType>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ded81ce359533a1498fb1e7a310eaf19</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/