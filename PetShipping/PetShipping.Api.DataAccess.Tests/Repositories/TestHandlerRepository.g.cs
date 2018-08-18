using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class HandlerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<HandlerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<HandlerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "Repositories")]
	public partial class HandlerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			Handler entity = new Handler();
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			Handler entity = new Handler();
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);

			var entity = new Handler();
			await repository.Create(entity);

			var record = await context.Set<Handler>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Handler>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Handler());

			var modifiedRecord = context.Set<Handler>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<HandlerRepository>> loggerMoc = HandlerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = HandlerRepositoryMoc.GetContext();
			var repository = new HandlerRepository(loggerMoc.Object, context);
			Handler entity = new Handler();
			context.Set<Handler>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Handler modifiedRecord = await context.Set<Handler>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>08e3fca04331e6d6d5922b4258e17c7c</Hash>
</Codenesium>*/