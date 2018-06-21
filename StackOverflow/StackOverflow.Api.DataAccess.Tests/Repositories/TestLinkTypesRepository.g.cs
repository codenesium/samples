using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class LinkTypesRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LinkTypesRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LinkTypesRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "LinkTypes")]
        [Trait("Area", "Repositories")]
        public partial class LinkTypesRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);

                        LinkTypes entity = new LinkTypes();
                        context.Set<LinkTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);

                        LinkTypes entity = new LinkTypes();
                        context.Set<LinkTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);

                        var entity = new LinkTypes();
                        await repository.Create(entity);

                        var record = await context.Set<LinkTypes>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);
                        LinkTypes entity = new LinkTypes();
                        context.Set<LinkTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<LinkTypes>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);
                        LinkTypes entity = new LinkTypes();
                        context.Set<LinkTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new LinkTypes());

                        var modifiedRecord = context.Set<LinkTypes>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LinkTypesRepository>> loggerMoc = LinkTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LinkTypesRepositoryMoc.GetContext();
                        var repository = new LinkTypesRepository(loggerMoc.Object, context);
                        LinkTypes entity = new LinkTypes();
                        context.Set<LinkTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        LinkTypes modifiedRecord = await context.Set<LinkTypes>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>d3d91ee7a7fd95ce30a48b97ca061206</Hash>
</Codenesium>*/