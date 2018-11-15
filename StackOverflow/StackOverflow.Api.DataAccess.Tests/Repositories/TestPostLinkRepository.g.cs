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
	public partial class PostLinkRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostLinkRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostLinkRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostLink")]
	[Trait("Area", "Repositories")]
	public partial class PostLinkRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			PostLink entity = new PostLink();
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			PostLink entity = new PostLink();
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			var entity = new PostLink();
			await repository.Create(entity);

			var record = await context.Set<PostLink>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostLink>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostLink());

			var modifiedRecord = context.Set<PostLink>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);
			PostLink entity = new PostLink();
			context.Set<PostLink>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostLink modifiedRecord = await context.Set<PostLink>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostLinkRepository>> loggerMoc = PostLinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostLinkRepositoryMoc.GetContext();
			var repository = new PostLinkRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>04386498710f4434870cc0a65b1fc21f</Hash>
</Codenesium>*/