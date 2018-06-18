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
        public partial class ChainRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ChainRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ChainRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Chain")]
        [Trait("Area", "Repositories")]
        public partial class ChainRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        Chain entity = new Chain();

                        context.Set<Chain>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        Chain entity = new Chain();

                        context.Set<Chain>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        var entity = new Chain();

                        await repository.Create(entity);

                        var record = await context.Set<Chain>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        Chain entity = new Chain();

                        context.Set<Chain>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Chain>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        Chain entity = new Chain();

                        context.Set<Chain>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Chain());

                        var modifiedRecord = context.Set<Chain>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ChainRepository>> loggerMoc = ChainRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ChainRepositoryMoc.GetContext();
                        var repository = new ChainRepository(loggerMoc.Object, context);

                        Chain entity = new Chain();

                        context.Set<Chain>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Chain modifiedRecord = await context.Set<Chain>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>91f411e38f33b6f389e179ca346a2452</Hash>
</Codenesium>*/