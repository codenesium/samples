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
	public partial class BadgesRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<BadgesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BadgesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Badges")]
	[Trait("Area", "Repositories")]
	public partial class BadgesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);

			Badges entity = new Badges();
			context.Set<Badges>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);

			Badges entity = new Badges();
			context.Set<Badges>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);

			var entity = new Badges();
			await repository.Create(entity);

			var record = await context.Set<Badges>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);
			Badges entity = new Badges();
			context.Set<Badges>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Badges>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);
			Badges entity = new Badges();
			context.Set<Badges>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Badges());

			var modifiedRecord = context.Set<Badges>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<BadgesRepository>> loggerMoc = BadgesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BadgesRepositoryMoc.GetContext();
			var repository = new BadgesRepository(loggerMoc.Object, context);
			Badges entity = new Badges();
			context.Set<Badges>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Badges modifiedRecord = await context.Set<Badges>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>681be481765ca82b840d372c6ad5fa16</Hash>
</Codenesium>*/