using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class FollowingRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<FollowingRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FollowingRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "Repositories")]
	public partial class FollowingRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			Following entity = new Following();
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			Following entity = new Following();
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			var entity = new Following();
			await repository.Create(entity);

			var record = await context.Set<Following>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UserId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Following>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Following());

			var modifiedRecord = context.Set<Following>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);
			Following entity = new Following();
			context.Set<Following>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.UserId);

			Following modifiedRecord = await context.Set<Following>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FollowingRepository>> loggerMoc = FollowingRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowingRepositoryMoc.GetContext();
			var repository = new FollowingRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6e90a2dca6811c38bcc97ffd6e3f1800</Hash>
</Codenesium>*/