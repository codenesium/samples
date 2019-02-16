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

namespace FileServiceNS.Api.DataAccess
{
	public partial class FileRepositoryMoc
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

		public static Mock<ILogger<FileRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FileRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "Repositories")]
	public partial class FileRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			File entity = new File();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			var entity = new File();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			await repository.Create(entity);

			var records = await context.Set<File>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<File>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<File>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			entity.SetProperties(default(int), 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<File>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e9e3a1df1f6016ffd2c799d31dce5a10</Hash>
</Codenesium>*/