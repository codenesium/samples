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
	public partial class PostsRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Posts")]
	[Trait("Area", "Repositories")]
	public partial class PostsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			Posts entity = new Posts();
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			Posts entity = new Posts();
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);

			var entity = new Posts();
			await repository.Create(entity);

			var record = await context.Set<Posts>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Posts>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Posts());

			var modifiedRecord = context.Set<Posts>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PostsRepository>> loggerMoc = PostsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostsRepositoryMoc.GetContext();
			var repository = new PostsRepository(loggerMoc.Object, context);
			Posts entity = new Posts();
			context.Set<Posts>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Posts modifiedRecord = await context.Set<Posts>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>bdf7d312f96e02f7fceda1e470a09c84</Hash>
</Codenesium>*/