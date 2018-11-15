using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class QuoteTweetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<QuoteTweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<QuoteTweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Repositories")]
	public partial class QuoteTweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			QuoteTweet entity = new QuoteTweet();
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			QuoteTweet entity = new QuoteTweet();
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.QuoteTweetId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			var entity = new QuoteTweet();
			await repository.Create(entity);

			var record = await context.Set<QuoteTweet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.QuoteTweetId);

			await repository.Update(record);

			var modifiedRecord = context.Set<QuoteTweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new QuoteTweet());

			var modifiedRecord = context.Set<QuoteTweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);
			QuoteTweet entity = new QuoteTweet();
			context.Set<QuoteTweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.QuoteTweetId);

			QuoteTweet modifiedRecord = await context.Set<QuoteTweet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<QuoteTweetRepository>> loggerMoc = QuoteTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = QuoteTweetRepositoryMoc.GetContext();
			var repository = new QuoteTweetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>93cb7d72fbb68225d491d500f813e591</Hash>
</Codenesium>*/