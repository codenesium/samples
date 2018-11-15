using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class TransactionHistoryArchiveRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TransactionHistoryArchiveRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionHistoryArchiveRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Repositories")]
	public partial class TransactionHistoryArchiveRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			var entity = new TransactionHistoryArchive();
			await repository.Create(entity);

			var record = await context.Set<TransactionHistoryArchive>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			await repository.Update(record);

			var modifiedRecord = context.Set<TransactionHistoryArchive>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TransactionHistoryArchive());

			var modifiedRecord = context.Set<TransactionHistoryArchive>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);
			TransactionHistoryArchive entity = new TransactionHistoryArchive();
			context.Set<TransactionHistoryArchive>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TransactionID);

			TransactionHistoryArchive modifiedRecord = await context.Set<TransactionHistoryArchive>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TransactionHistoryArchiveRepository>> loggerMoc = TransactionHistoryArchiveRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryArchiveRepositoryMoc.GetContext();
			var repository = new TransactionHistoryArchiveRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c87a5818f484ca98b2645b5da64791b1</Hash>
</Codenesium>*/