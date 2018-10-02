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
	public partial class RetweetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<RetweetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RetweetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Retweet")]
	[Trait("Area", "Repositories")]
	public partial class RetweetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			Retweet entity = new Retweet();
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			Retweet entity = new Retweet();
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);

			var entity = new Retweet();
			await repository.Create(entity);

			var record = await context.Set<Retweet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Retweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Retweet());

			var modifiedRecord = context.Set<Retweet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<RetweetRepository>> loggerMoc = RetweetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RetweetRepositoryMoc.GetContext();
			var repository = new RetweetRepository(loggerMoc.Object, context);
			Retweet entity = new Retweet();
			context.Set<Retweet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Retweet modifiedRecord = await context.Set<Retweet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>8cbf0d19aa170a99faf83989b9b78a9d</Hash>
</Codenesium>*/