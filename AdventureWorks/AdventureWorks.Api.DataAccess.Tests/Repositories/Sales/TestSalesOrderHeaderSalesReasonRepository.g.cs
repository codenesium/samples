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
        public partial class SalesOrderHeaderSalesReasonRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<SalesOrderHeaderSalesReasonRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderHeaderSalesReason")]
        [Trait("Area", "Repositories")]
        public partial class SalesOrderHeaderSalesReasonRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        context.Set<SalesOrderHeaderSalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        context.Set<SalesOrderHeaderSalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SalesOrderID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        var entity = new SalesOrderHeaderSalesReason();

                        await repository.Create(entity);

                        var record = await context.Set<SalesOrderHeaderSalesReason>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        context.Set<SalesOrderHeaderSalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SalesOrderID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<SalesOrderHeaderSalesReason>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        context.Set<SalesOrderHeaderSalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new SalesOrderHeaderSalesReason());

                        var modifiedRecord = context.Set<SalesOrderHeaderSalesReason>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<SalesOrderHeaderSalesReasonRepository>> loggerMoc = SalesOrderHeaderSalesReasonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SalesOrderHeaderSalesReasonRepositoryMoc.GetContext();
                        var repository = new SalesOrderHeaderSalesReasonRepository(loggerMoc.Object, context);

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        context.Set<SalesOrderHeaderSalesReason>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.SalesOrderID);

                        SalesOrderHeaderSalesReason modifiedRecord = await context.Set<SalesOrderHeaderSalesReason>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>4d558e7a3eacf276e50817a84f9ebbe5</Hash>
</Codenesium>*/