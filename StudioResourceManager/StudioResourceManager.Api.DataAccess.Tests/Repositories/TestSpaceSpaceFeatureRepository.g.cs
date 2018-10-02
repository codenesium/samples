using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class SpaceSpaceFeatureRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SpaceSpaceFeatureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpaceSpaceFeatureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Repositories")]
	public partial class SpaceSpaceFeatureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);

			var entity = new SpaceSpaceFeature();
			await repository.Create(entity);

			var record = await context.Set<SpaceSpaceFeature>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SpaceSpaceFeature>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SpaceSpaceFeature());

			var modifiedRecord = context.Set<SpaceSpaceFeature>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SpaceSpaceFeatureRepository>> loggerMoc = SpaceSpaceFeatureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceSpaceFeatureRepositoryMoc.GetContext();
			var repository = new SpaceSpaceFeatureRepository(loggerMoc.Object, context);
			SpaceSpaceFeature entity = new SpaceSpaceFeature();
			context.Set<SpaceSpaceFeature>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SpaceSpaceFeature modifiedRecord = await context.Set<SpaceSpaceFeature>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>edcfaf2801fe0145c306bd723494894d</Hash>
</Codenesium>*/