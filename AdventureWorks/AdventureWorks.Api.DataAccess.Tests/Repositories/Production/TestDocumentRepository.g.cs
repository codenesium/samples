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
	public partial class DocumentRepositoryMoc
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

		public static Mock<ILogger<DocumentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DocumentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Document")]
	[Trait("Area", "Repositories")]
	public partial class DocumentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);

			Document entity = new Document();
			entity.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Rowguid);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);

			var entity = new Document();
			entity.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			await repository.Create(entity);

			var records = await context.Set<Document>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			entity.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Rowguid);

			await repository.Update(record);

			var records = await context.Set<Document>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			entity.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Document>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			entity.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Rowguid);

			var records = await context.Set<Document>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(Guid));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2708bd491f60343dd6d330c36097b0f5</Hash>
</Codenesium>*/