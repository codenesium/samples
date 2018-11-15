using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Repositories")]
	public partial class PostHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			PostHistory entity = new PostHistory();
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			PostHistory entity = new PostHistory();
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			var entity = new PostHistory();
			await repository.Create(entity);

			var record = await context.Set<PostHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostHistory());

			var modifiedRecord = context.Set<PostHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);
			PostHistory entity = new PostHistory();
			context.Set<PostHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostHistory modifiedRecord = await context.Set<PostHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostHistoryRepository>> loggerMoc = PostHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryRepositoryMoc.GetContext();
			var repository = new PostHistoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>576f8764628fdd27b6c11f4d22ec0779</Hash>
</Codenesium>*/