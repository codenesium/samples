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
	public partial class ScrapReasonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ScrapReasonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ScrapReasonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "Repositories")]
	public partial class ScrapReasonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			ScrapReason entity = new ScrapReason();
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			ScrapReason entity = new ScrapReason();
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ScrapReasonID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);

			var entity = new ScrapReason();
			await repository.Create(entity);

			var record = await context.Set<ScrapReason>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ScrapReasonID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ScrapReason>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ScrapReason());

			var modifiedRecord = context.Set<ScrapReason>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ScrapReasonRepository>> loggerMoc = ScrapReasonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ScrapReasonRepositoryMoc.GetContext();
			var repository = new ScrapReasonRepository(loggerMoc.Object, context);
			ScrapReason entity = new ScrapReason();
			context.Set<ScrapReason>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ScrapReasonID);

			ScrapReason modifiedRecord = await context.Set<ScrapReason>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>d23f5f2cb042318dbe4a12da8ed1c37d</Hash>
</Codenesium>*/