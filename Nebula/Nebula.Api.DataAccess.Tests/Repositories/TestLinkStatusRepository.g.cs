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
        public partial class LinkStatusRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LinkStatusRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LinkStatusRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "Repositories")]
        public partial class LinkStatusRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        LinkStatus entity = new LinkStatus();

                        context.Set<LinkStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        LinkStatus entity = new LinkStatus();

                        context.Set<LinkStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        var entity = new LinkStatus();

                        await repository.Create(entity);

                        var record = await context.Set<LinkStatus>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        LinkStatus entity = new LinkStatus();

                        context.Set<LinkStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<LinkStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        LinkStatus entity = new LinkStatus();

                        context.Set<LinkStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new LinkStatus());

                        var modifiedRecord = context.Set<LinkStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
                        var repository = new LinkStatusRepository(loggerMoc.Object, context);

                        LinkStatus entity = new LinkStatus();

                        context.Set<LinkStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        LinkStatus modifiedRecord = await context.Set<LinkStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>2703b632889cd979b1014b380b8b1702</Hash>
</Codenesium>*/