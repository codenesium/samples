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
	public partial class CommentRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CommentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CommentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "Repositories")]
	public partial class CommentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			Comment entity = new Comment();
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			Comment entity = new Comment();
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);

			var entity = new Comment();
			await repository.Create(entity);

			var record = await context.Set<Comment>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Comment>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Comment());

			var modifiedRecord = context.Set<Comment>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CommentRepository>> loggerMoc = CommentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentRepositoryMoc.GetContext();
			var repository = new CommentRepository(loggerMoc.Object, context);
			Comment entity = new Comment();
			context.Set<Comment>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Comment modifiedRecord = await context.Set<Comment>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>2ccc6928183355df796f3c16c9d0915a</Hash>
</Codenesium>*/