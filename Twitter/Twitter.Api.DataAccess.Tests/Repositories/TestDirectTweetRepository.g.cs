using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class DirectTweetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DirectTweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DirectTweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Repositories")]
	public partial class DirectTweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);

			DirectTweet entity = new DirectTweet();
			context.Set<DirectTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);

			DirectTweet entity = new DirectTweet();
			context.Set<DirectTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);

			var entity = new DirectTweet();
			await repository.Create(entity);

			var record = await context.Set<DirectTweet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);
			DirectTweet entity = new DirectTweet();
			context.Set<DirectTweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			await repository.Update(record);

			var modifiedRecord = context.Set<DirectTweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);
			DirectTweet entity = new DirectTweet();
			context.Set<DirectTweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new DirectTweet());

			var modifiedRecord = context.Set<DirectTweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<DirectTweetRepository>> loggerMoc = DirectTweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DirectTweetRepositoryMoc.GetContext();
			var repository = new DirectTweetRepository(loggerMoc.Object, context);
			DirectTweet entity = new DirectTweet();
			context.Set<DirectTweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TweetId);

			DirectTweet modifiedRecord = await context.Set<DirectTweet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>974baf2b770fafd38ccef8015b7a5fea</Hash>
</Codenesium>*/