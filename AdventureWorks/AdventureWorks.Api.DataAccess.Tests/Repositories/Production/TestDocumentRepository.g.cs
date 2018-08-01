using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class DocumentRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			Document entity = new Document();
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);

			Document entity = new Document();
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
			await repository.Create(entity);

			var record = await context.Set<Document>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Rowguid);

			await repository.Update(record);

			var modifiedRecord = context.Set<Document>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Document());

			var modifiedRecord = context.Set<Document>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<DocumentRepository>> loggerMoc = DocumentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DocumentRepositoryMoc.GetContext();
			var repository = new DocumentRepository(loggerMoc.Object, context);
			Document entity = new Document();
			context.Set<Document>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Rowguid);

			Document modifiedRecord = await context.Set<Document>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>896ca58cea7c95ac9483a6734f2a1255</Hash>
</Codenesium>*/