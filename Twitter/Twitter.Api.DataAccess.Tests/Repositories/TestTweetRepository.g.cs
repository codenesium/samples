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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TweetRepository>> loggerMoc = TweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TweetRepositoryMoc.GetContext();
			var repository = new TweetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>4e5c0965c460adba51e171c65521d7e1</Hash>
</Codenesium>*/