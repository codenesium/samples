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
        public partial class LinkLogRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LinkLogRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LinkLogRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "LinkLog")]
        [Trait("Area", "Repositories")]
        public partial class LinkLogRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        LinkLog entity = new LinkLog();

                        context.Set<LinkLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        LinkLog entity = new LinkLog();

                        context.Set<LinkLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        var entity = new LinkLog();

                        await repository.Create(entity);

                        var record = await context.Set<LinkLog>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        LinkLog entity = new LinkLog();

                        context.Set<LinkLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<LinkLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        LinkLog entity = new LinkLog();

                        context.Set<LinkLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new LinkLog());

                        var modifiedRecord = context.Set<LinkLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
                        var repository = new LinkLogRepository(loggerMoc.Object, context);

                        LinkLog entity = new LinkLog();

                        context.Set<LinkLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        LinkLog modifiedRecord = await context.Set<LinkLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>64b97add3cda8df4c95144c7a90b72de</Hash>
</Codenesium>*/