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
	public partial class LinkStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LinkStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "Repositories")]
	public partial class LinkStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);

			LinkStatu entity = new LinkStatu();
			context.Set<LinkStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);

			LinkStatu entity = new LinkStatu();
			context.Set<LinkStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);

			var entity = new LinkStatu();
			await repository.Create(entity);

			var record = await context.Set<LinkStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);
			LinkStatu entity = new LinkStatu();
			context.Set<LinkStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<LinkStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);
			LinkStatu entity = new LinkStatu();
			context.Set<LinkStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new LinkStatu());

			var modifiedRecord = context.Set<LinkStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LinkStatuRepository>> loggerMoc = LinkStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatuRepositoryMoc.GetContext();
			var repository = new LinkStatuRepository(loggerMoc.Object, context);
			LinkStatu entity = new LinkStatu();
			context.Set<LinkStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			LinkStatu modifiedRecord = await context.Set<LinkStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0b48ca4372c0e4b0b61a277795e7fe80</Hash>
</Codenesium>*/