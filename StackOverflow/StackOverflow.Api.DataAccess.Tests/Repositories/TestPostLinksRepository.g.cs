using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostLinksRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostLinksRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostLinksRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostLinks")]
	[Trait("Area", "Repositories")]
	public partial class PostLinksRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);

			PostLinks entity = new PostLinks();
			context.Set<PostLinks>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);

			PostLinks entity = new PostLinks();
			context.Set<PostLinks>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);

			var entity = new PostLinks();
			await repository.Create(entity);

			var record = await context.Set<PostLinks>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);
			PostLinks entity = new PostLinks();
			context.Set<PostLinks>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostLinks>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);
			PostLinks entity = new PostLinks();
			context.Set<PostLinks>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostLinks());

			var modifiedRecord = context.Set<PostLinks>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PostLinksRepository>> loggerMoc = PostLinksRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinksRepositoryMoc.GetContext();
			var repository = new PostLinksRepository(loggerMoc.Object, context);
			PostLinks entity = new PostLinks();
			context.Set<PostLinks>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostLinks modifiedRecord = await context.Set<PostLinks>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>e70fe8bcc0a6d0649193f1ecb035e008</Hash>
</Codenesium>*/