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
        public partial class SalesReasonRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<SalesReasonRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<SalesReasonRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "SalesReason")]
        [Trait("Area", "Repositories")]
        public partial class SalesReasonRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);

                        SalesReason entity = new SalesReason();
                        context.Set<SalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);

                        SalesReason entity = new SalesReason();
                        context.Set<SalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SalesReasonID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);

                        var entity = new SalesReason();
                        await repository.Create(entity);

                        var record = await context.Set<SalesReason>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);
                        SalesReason entity = new SalesReason();
                        context.Set<SalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SalesReasonID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<SalesReason>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);
                        SalesReason entity = new SalesReason();
                        context.Set<SalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new SalesReason());

                        var modifiedRecord = context.Set<SalesReason>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<SalesReasonRepository>> loggerMoc = SalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesReasonRepository(loggerMoc.Object, context);
                        SalesReason entity = new SalesReason();
                        context.Set<SalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.SalesReasonID);

                        SalesReason modifiedRecord = await context.Set<SalesReason>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>8f0e8cf2468e38c6efe18f16f9f2f583</Hash>
</Codenesium>*/