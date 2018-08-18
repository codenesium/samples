using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class FeedRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<FeedRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FeedRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Feed")]
	[Trait("Area", "Repositories")]
	public partial class FeedRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);

			Feed entity = new Feed();
			context.Set<Feed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);

			Feed entity = new Feed();
			context.Set<Feed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);

			var entity = new Feed();
			await repository.Create(entity);

			var record = await context.Set<Feed>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);
			Feed entity = new Feed();
			context.Set<Feed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Feed>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);
			Feed entity = new Feed();
			context.Set<Feed>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Feed());

			var modifiedRecord = context.Set<Feed>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<FeedRepository>> loggerMoc = FeedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FeedRepositoryMoc.GetContext();
			var repository = new FeedRepository(loggerMoc.Object, context);
			Feed entity = new Feed();
			context.Set<Feed>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Feed modifiedRecord = await context.Set<Feed>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0468551e428af309fc22b61e0f94a717</Hash>
</Codenesium>*/