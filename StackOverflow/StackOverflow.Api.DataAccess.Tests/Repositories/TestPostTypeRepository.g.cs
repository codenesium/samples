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
	public partial class PostTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "Repositories")]
	public partial class PostTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);

			PostType entity = new PostType();
			context.Set<PostType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);

			PostType entity = new PostType();
			context.Set<PostType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);

			var entity = new PostType();
			await repository.Create(entity);

			var record = await context.Set<PostType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);
			PostType entity = new PostType();
			context.Set<PostType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);
			PostType entity = new PostType();
			context.Set<PostType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostType());

			var modifiedRecord = context.Set<PostType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);
			PostType entity = new PostType();
			context.Set<PostType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostType modifiedRecord = await context.Set<PostType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PostTypeRepository>> loggerMoc = PostTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypeRepositoryMoc.GetContext();
			var repository = new PostTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>cac43ce495cb719ec1455072bb3360d9</Hash>
</Codenesium>*/