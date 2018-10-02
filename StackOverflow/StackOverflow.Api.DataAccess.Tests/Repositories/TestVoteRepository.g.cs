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
	public partial class VoteRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VoteRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VoteRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Vote")]
	[Trait("Area", "Repositories")]
	public partial class VoteRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			Vote entity = new Vote();
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			Vote entity = new Vote();
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);

			var entity = new Vote();
			await repository.Create(entity);

			var record = await context.Set<Vote>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Vote>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Vote());

			var modifiedRecord = context.Set<Vote>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VoteRepository>> loggerMoc = VoteRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteRepositoryMoc.GetContext();
			var repository = new VoteRepository(loggerMoc.Object, context);
			Vote entity = new Vote();
			context.Set<Vote>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Vote modifiedRecord = await context.Set<Vote>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>84816b5312abcc5d571de76a46fcc03b</Hash>
</Codenesium>*/