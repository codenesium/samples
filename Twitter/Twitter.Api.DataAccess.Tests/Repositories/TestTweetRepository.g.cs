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
	public partial class TweetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "Repositories")]
	public partial class TweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			Tweet entity = new Tweet();
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			Tweet entity = new Tweet();
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			var entity = new Tweet();
			await repository.Create(entity);

			var record = await context.Set<Tweet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.TweetId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Tweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Tweet());

			var modifiedRecord = context.Set<Tweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);
			Tweet entity = new Tweet();
			context.Set<Tweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.TweetId);

			Tweet modifiedRecord = await context.Set<Tweet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>37e88b640187fc8438dfcc1dec8d60da</Hash>
</Codenesium>*/