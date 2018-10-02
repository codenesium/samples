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
	public partial class ChainStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ChainStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ChainStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "Repositories")]
	public partial class ChainStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);

			ChainStatu entity = new ChainStatu();
			context.Set<ChainStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);

			ChainStatu entity = new ChainStatu();
			context.Set<ChainStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);

			var entity = new ChainStatu();
			await repository.Create(entity);

			var record = await context.Set<ChainStatu>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);
			ChainStatu entity = new ChainStatu();
			context.Set<ChainStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ChainStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);
			ChainStatu entity = new ChainStatu();
			context.Set<ChainStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ChainStatu());

			var modifiedRecord = context.Set<ChainStatu>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ChainStatuRepository>> loggerMoc = ChainStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatuRepositoryMoc.GetContext();
			var repository = new ChainStatuRepository(loggerMoc.Object, context);
			ChainStatu entity = new ChainStatu();
			context.Set<ChainStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ChainStatu modifiedRecord = await context.Set<ChainStatu>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>e2c3e5d9f91464dacacae3d28ab277b3</Hash>
</Codenesium>*/