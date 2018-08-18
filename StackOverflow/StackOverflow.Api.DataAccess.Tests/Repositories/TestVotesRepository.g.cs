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
	public partial class VotesRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VotesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VotesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Votes")]
	[Trait("Area", "Repositories")]
	public partial class VotesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			Votes entity = new Votes();
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			Votes entity = new Votes();
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);

			var entity = new Votes();
			await repository.Create(entity);

			var record = await context.Set<Votes>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Votes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Votes());

			var modifiedRecord = context.Set<Votes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VotesRepository>> loggerMoc = VotesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VotesRepositoryMoc.GetContext();
			var repository = new VotesRepository(loggerMoc.Object, context);
			Votes entity = new Votes();
			context.Set<Votes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Votes modifiedRecord = await context.Set<Votes>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>51780dcdddf7640f80d13b05a6d89baf</Hash>
</Codenesium>*/