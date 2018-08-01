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
	public partial class CommentsRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CommentsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CommentsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Comments")]
	[Trait("Area", "Repositories")]
	public partial class CommentsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);

			Comments entity = new Comments();
			context.Set<Comments>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);

			Comments entity = new Comments();
			context.Set<Comments>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);

			var entity = new Comments();
			await repository.Create(entity);

			var record = await context.Set<Comments>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);
			Comments entity = new Comments();
			context.Set<Comments>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Comments>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);
			Comments entity = new Comments();
			context.Set<Comments>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Comments());

			var modifiedRecord = context.Set<Comments>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CommentsRepository>> loggerMoc = CommentsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommentsRepositoryMoc.GetContext();
			var repository = new CommentsRepository(loggerMoc.Object, context);
			Comments entity = new Comments();
			context.Set<Comments>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Comments modifiedRecord = await context.Set<Comments>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>8b133efd576e446d70de0b38588b8597</Hash>
</Codenesium>*/