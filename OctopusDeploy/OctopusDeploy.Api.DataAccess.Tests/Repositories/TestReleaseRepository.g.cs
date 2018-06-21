using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ReleaseRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ReleaseRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ReleaseRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Release")]
        [Trait("Area", "Repositories")]
        public partial class ReleaseRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);

                        Release entity = new Release();
                        context.Set<Release>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);

                        Release entity = new Release();
                        context.Set<Release>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);

                        var entity = new Release();
                        await repository.Create(entity);

                        var record = await context.Set<Release>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);
                        Release entity = new Release();
                        context.Set<Release>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Release>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);
                        Release entity = new Release();
                        context.Set<Release>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Release());

                        var modifiedRecord = context.Set<Release>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ReleaseRepository>> loggerMoc = ReleaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ReleaseRepositoryMoc.GetContext();
                        var repository = new ReleaseRepository(loggerMoc.Object, context);
                        Release entity = new Release();
                        context.Set<Release>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Release modifiedRecord = await context.Set<Release>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>c32c8bb41b7dc30616f49eb29cb58f66</Hash>
</Codenesium>*/