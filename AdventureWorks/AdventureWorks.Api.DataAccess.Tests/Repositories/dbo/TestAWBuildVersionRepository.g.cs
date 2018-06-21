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
        public partial class AWBuildVersionRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<AWBuildVersionRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<AWBuildVersionRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "AWBuildVersion")]
        [Trait("Area", "Repositories")]
        public partial class AWBuildVersionRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

                        AWBuildVersion entity = new AWBuildVersion();
                        context.Set<AWBuildVersion>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

                        AWBuildVersion entity = new AWBuildVersion();
                        context.Set<AWBuildVersion>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SystemInformationID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);

                        var entity = new AWBuildVersion();
                        await repository.Create(entity);

                        var record = await context.Set<AWBuildVersion>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
                        AWBuildVersion entity = new AWBuildVersion();
                        context.Set<AWBuildVersion>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SystemInformationID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<AWBuildVersion>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
                        AWBuildVersion entity = new AWBuildVersion();
                        context.Set<AWBuildVersion>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new AWBuildVersion());

                        var modifiedRecord = context.Set<AWBuildVersion>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<AWBuildVersionRepository>> loggerMoc = AWBuildVersionRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AWBuildVersionRepositoryMoc.GetContext();
                        var repository = new AWBuildVersionRepository(loggerMoc.Object, context);
                        AWBuildVersion entity = new AWBuildVersion();
                        context.Set<AWBuildVersion>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.SystemInformationID);

                        AWBuildVersion modifiedRecord = await context.Set<AWBuildVersion>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>fa5267d02da23be1807c68588855eb3c</Hash>
</Codenesium>*/