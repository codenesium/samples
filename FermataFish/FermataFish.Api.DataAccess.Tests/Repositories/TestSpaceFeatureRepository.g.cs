using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FermataFishNS.Api.DataAccess
{
	public partial class SpaceFeatureRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SpaceFeatureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpaceFeatureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Repositories")]
	public partial class SpaceFeatureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);

			SpaceFeature entity = new SpaceFeature();
			context.Set<SpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);

			SpaceFeature entity = new SpaceFeature();
			context.Set<SpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);

			var entity = new SpaceFeature();
			await repository.Create(entity);

			var record = await context.Set<SpaceFeature>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);
			SpaceFeature entity = new SpaceFeature();
			context.Set<SpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SpaceFeature>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);
			SpaceFeature entity = new SpaceFeature();
			context.Set<SpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SpaceFeature());

			var modifiedRecord = context.Set<SpaceFeature>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SpaceFeatureRepository>> loggerMoc = SpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceFeatureRepository(loggerMoc.Object, context);
			SpaceFeature entity = new SpaceFeature();
			context.Set<SpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SpaceFeature modifiedRecord = await context.Set<SpaceFeature>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>9950ae23e9e47e9933b8f35b495ddbaf</Hash>
</Codenesium>*/