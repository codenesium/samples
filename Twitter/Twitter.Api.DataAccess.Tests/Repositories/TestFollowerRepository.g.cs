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
	public partial class FollowerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<FollowerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FollowerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "Repositories")]
	public partial class FollowerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			Follower entity = new Follower();
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			Follower entity = new Follower();
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			var entity = new Follower();
			await repository.Create(entity);

			var record = await context.Set<Follower>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Follower>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Follower());

			var modifiedRecord = context.Set<Follower>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);
			Follower entity = new Follower();
			context.Set<Follower>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Follower modifiedRecord = await context.Set<Follower>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FollowerRepository>> loggerMoc = FollowerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FollowerRepositoryMoc.GetContext();
			var repository = new FollowerRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e01a7c42fa8981bdbcfe6a432eb0984c</Hash>
</Codenesium>*/