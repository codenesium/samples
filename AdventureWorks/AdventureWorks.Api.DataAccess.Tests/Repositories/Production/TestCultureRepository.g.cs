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
	public partial class CultureRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CultureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CultureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Culture")]
	[Trait("Area", "Repositories")]
	public partial class CultureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			Culture entity = new Culture();
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			Culture entity = new Culture();
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);

			var entity = new Culture();
			await repository.Create(entity);

			var record = await context.Set<Culture>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Culture>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Culture());

			var modifiedRecord = context.Set<Culture>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CultureRepository>> loggerMoc = CultureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CultureRepositoryMoc.GetContext();
			var repository = new CultureRepository(loggerMoc.Object, context);
			Culture entity = new Culture();
			context.Set<Culture>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CultureID);

			Culture modifiedRecord = await context.Set<Culture>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>fcaae5abff9713ce4aea705475ba5fee</Hash>
</Codenesium>*/