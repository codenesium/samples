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
	public partial class PostTypesRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostTypesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostTypesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PostTypes")]
	[Trait("Area", "Repositories")]
	public partial class PostTypesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);

			PostTypes entity = new PostTypes();
			context.Set<PostTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);

			PostTypes entity = new PostTypes();
			context.Set<PostTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);

			var entity = new PostTypes();
			await repository.Create(entity);

			var record = await context.Set<PostTypes>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);
			PostTypes entity = new PostTypes();
			context.Set<PostTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<PostTypes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);
			PostTypes entity = new PostTypes();
			context.Set<PostTypes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PostTypes());

			var modifiedRecord = context.Set<PostTypes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PostTypesRepository>> loggerMoc = PostTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostTypesRepositoryMoc.GetContext();
			var repository = new PostTypesRepository(loggerMoc.Object, context);
			PostTypes entity = new PostTypes();
			context.Set<PostTypes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			PostTypes modifiedRecord = await context.Set<PostTypes>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>3d7ccb8a93af7f1fe56060114a043af3</Hash>
</Codenesium>*/