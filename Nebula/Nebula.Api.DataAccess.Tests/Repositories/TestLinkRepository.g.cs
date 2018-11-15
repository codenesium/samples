using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LinkRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "Repositories")]
	public partial class LinkRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			Link entity = new Link();
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			Link entity = new Link();
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			var entity = new Link();
			await repository.Create(entity);

			var record = await context.Set<Link>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Link>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Link());

			var modifiedRecord = context.Set<Link>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Link modifiedRecord = await context.Set<Link>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>9515108f5f87da14d4a00792f7f06e2d</Hash>
</Codenesium>*/