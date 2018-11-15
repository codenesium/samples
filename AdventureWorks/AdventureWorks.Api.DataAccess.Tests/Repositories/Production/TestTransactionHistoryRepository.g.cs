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
	public partial class TransactionHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TransactionHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TransactionHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Repositories")]
	public partial class TransactionHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			TransactionHistory entity = new TransactionHistory();
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			TransactionHistory entity = new TransactionHistory();
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			var entity = new TransactionHistory();
			await repository.Create(entity);

			var record = await context.Set<TransactionHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TransactionID);

			await repository.Update(record);

			var modifiedRecord = context.Set<TransactionHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TransactionHistory());

			var modifiedRecord = context.Set<TransactionHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);
			TransactionHistory entity = new TransactionHistory();
			context.Set<TransactionHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TransactionID);

			TransactionHistory modifiedRecord = await context.Set<TransactionHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TransactionHistoryRepository>> loggerMoc = TransactionHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TransactionHistoryRepositoryMoc.GetContext();
			var repository = new TransactionHistoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e448c40ec2f82658e79daed99acd6e15</Hash>
</Codenesium>*/