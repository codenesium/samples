using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
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
		public async void Delete()
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
	}
}

/*<Codenesium>
    <Hash>d788b9b126170fc5e53ce88f9a293dd4</Hash>
</Codenesium>*/