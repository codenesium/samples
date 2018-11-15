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
	public partial class BadgeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<BadgeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BadgeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Badge")]
	[Trait("Area", "Repositories")]
	public partial class BadgeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);

			Badge entity = new Badge();
			context.Set<Badge>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);

			Badge entity = new Badge();
			context.Set<Badge>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);

			var entity = new Badge();
			await repository.Create(entity);

			var record = await context.Set<Badge>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);
			Badge entity = new Badge();
			context.Set<Badge>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Badge>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);
			Badge entity = new Badge();
			context.Set<Badge>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Badge());

			var modifiedRecord = context.Set<Badge>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);
			Badge entity = new Badge();
			context.Set<Badge>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Badge modifiedRecord = await context.Set<Badge>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<BadgeRepository>> loggerMoc = BadgeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgeRepositoryMoc.GetContext();
			var repository = new BadgeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>3c55310664de133d7f291914f0a44a3f</Hash>
</Codenesium>*/