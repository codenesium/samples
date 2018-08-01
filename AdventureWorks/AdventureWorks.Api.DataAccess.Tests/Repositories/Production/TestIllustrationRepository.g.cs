using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class IllustrationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<IllustrationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<IllustrationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Illustration")]
	[Trait("Area", "Repositories")]
	public partial class IllustrationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			Illustration entity = new Illustration();
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			Illustration entity = new Illustration();
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.IllustrationID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);

			var entity = new Illustration();
			await repository.Create(entity);

			var record = await context.Set<Illustration>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.IllustrationID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Illustration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Illustration());

			var modifiedRecord = context.Set<Illustration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<IllustrationRepository>> loggerMoc = IllustrationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IllustrationRepositoryMoc.GetContext();
			var repository = new IllustrationRepository(loggerMoc.Object, context);
			Illustration entity = new Illustration();
			context.Set<Illustration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.IllustrationID);

			Illustration modifiedRecord = await context.Set<Illustration>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>513915bb635911b70f88e4775edf8f68</Hash>
</Codenesium>*/