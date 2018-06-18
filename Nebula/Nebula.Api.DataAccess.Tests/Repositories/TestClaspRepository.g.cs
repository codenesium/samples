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
        public partial class ClaspRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ClaspRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ClaspRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Clasp")]
        [Trait("Area", "Repositories")]
        public partial class ClaspRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        Clasp entity = new Clasp();

                        context.Set<Clasp>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        Clasp entity = new Clasp();

                        context.Set<Clasp>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        var entity = new Clasp();

                        await repository.Create(entity);

                        var record = await context.Set<Clasp>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        Clasp entity = new Clasp();

                        context.Set<Clasp>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Clasp>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        Clasp entity = new Clasp();

                        context.Set<Clasp>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Clasp());

                        var modifiedRecord = context.Set<Clasp>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ClaspRepository>> loggerMoc = ClaspRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClaspRepositoryMoc.GetContext();
                        var repository = new ClaspRepository(loggerMoc.Object, context);

                        Clasp entity = new Clasp();

                        context.Set<Clasp>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Clasp modifiedRecord = await context.Set<Clasp>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>583a14a7a059c9966176f2d5ea903ed2</Hash>
</Codenesium>*/