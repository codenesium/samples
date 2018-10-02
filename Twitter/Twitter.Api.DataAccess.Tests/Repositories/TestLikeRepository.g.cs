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
	public partial class LikeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LikeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LikeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Like")]
	[Trait("Area", "Repositories")]
	public partial class LikeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);

			Like entity = new Like();
			context.Set<Like>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);

			Like entity = new Like();
			context.Set<Like>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LikeId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);

			var entity = new Like();
			await repository.Create(entity);

			var record = await context.Set<Like>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);
			Like entity = new Like();
			context.Set<Like>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LikeId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Like>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);
			Like entity = new Like();
			context.Set<Like>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Like());

			var modifiedRecord = context.Set<Like>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LikeRepository>> loggerMoc = LikeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LikeRepositoryMoc.GetContext();
			var repository = new LikeRepository(loggerMoc.Object, context);
			Like entity = new Like();
			context.Set<Like>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.LikeId);

			Like modifiedRecord = await context.Set<Like>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>2c841dd98683054778fb577102cb7d98</Hash>
</Codenesium>*/