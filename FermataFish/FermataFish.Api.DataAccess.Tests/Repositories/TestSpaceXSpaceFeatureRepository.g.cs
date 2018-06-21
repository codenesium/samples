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
        public partial class SpaceXSpaceFeatureRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<SpaceXSpaceFeatureRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<SpaceXSpaceFeatureRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "Repositories")]
        public partial class SpaceXSpaceFeatureRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);

                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
                        context.Set<SpaceXSpaceFeature>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);

                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
                        context.Set<SpaceXSpaceFeature>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);

                        var entity = new SpaceXSpaceFeature();
                        await repository.Create(entity);

                        var record = await context.Set<SpaceXSpaceFeature>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);
                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
                        context.Set<SpaceXSpaceFeature>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<SpaceXSpaceFeature>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);
                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
                        context.Set<SpaceXSpaceFeature>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new SpaceXSpaceFeature());

                        var modifiedRecord = context.Set<SpaceXSpaceFeature>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<SpaceXSpaceFeatureRepository>> loggerMoc = SpaceXSpaceFeatureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpaceXSpaceFeatureRepositoryMoc.GetContext();
                        var repository = new SpaceXSpaceFeatureRepository(loggerMoc.Object, context);
                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
                        context.Set<SpaceXSpaceFeature>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        SpaceXSpaceFeature modifiedRecord = await context.Set<SpaceXSpaceFeature>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>d3a788a24a437252599caecf1a4d304b</Hash>
</Codenesium>*/