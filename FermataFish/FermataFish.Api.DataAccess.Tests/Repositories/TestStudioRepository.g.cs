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
        public partial class StudioRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<StudioRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<StudioRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Studio")]
        [Trait("Area", "Repositories")]
        public partial class StudioRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);

                        Studio entity = new Studio();
                        context.Set<Studio>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);

                        Studio entity = new Studio();
                        context.Set<Studio>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);

                        var entity = new Studio();
                        await repository.Create(entity);

                        var record = await context.Set<Studio>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);
                        Studio entity = new Studio();
                        context.Set<Studio>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Studio>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);
                        Studio entity = new Studio();
                        context.Set<Studio>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Studio());

                        var modifiedRecord = context.Set<Studio>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<StudioRepository>> loggerMoc = StudioRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudioRepositoryMoc.GetContext();
                        var repository = new StudioRepository(loggerMoc.Object, context);
                        Studio entity = new Studio();
                        context.Set<Studio>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Studio modifiedRecord = await context.Set<Studio>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>e5e5c6923e2d6c19ef67e1e5cb5b22ed</Hash>
</Codenesium>*/