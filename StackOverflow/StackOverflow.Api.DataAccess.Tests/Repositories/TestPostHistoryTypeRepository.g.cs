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
	public partial class PostHistoryTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostHistoryTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostHistoryTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Repositories")]
	public partial class PostHistoryTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);

			PostHistoryType entity = new PostHistoryType();
			context.Set<PostHistoryType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);

			PostHistoryType entity = new PostHistoryType();
			context.Set<PostHistoryType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);

			var entity = new PostHistoryType();
			await repository.Create(entity);

			var record = await context.Set<PostHistoryType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);
			PostHistoryType entity = new PostHistoryType();
			context.Set<PostHistoryType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostHistoryType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);
			PostHistoryType entity = new PostHistoryType();
			context.Set<PostHistoryType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostHistoryType());

			var modifiedRecord = context.Set<PostHistoryType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);
			PostHistoryType entity = new PostHistoryType();
			context.Set<PostHistoryType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostHistoryType modifiedRecord = await context.Set<PostHistoryType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostHistoryTypeRepository>> loggerMoc = PostHistoryTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostHistoryTypeRepositoryMoc.GetContext();
			var repository = new PostHistoryTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>bed419060e22c503e3b60795f482c7e0</Hash>
</Codenesium>*/