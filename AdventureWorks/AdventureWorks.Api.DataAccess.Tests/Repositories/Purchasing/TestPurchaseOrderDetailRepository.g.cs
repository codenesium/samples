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
        public partial class PurchaseOrderDetailRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PurchaseOrderDetailRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PurchaseOrderDetailRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "Repositories")]
        public partial class PurchaseOrderDetailRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        context.Set<PurchaseOrderDetail>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        context.Set<PurchaseOrderDetail>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.PurchaseOrderID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        var entity = new PurchaseOrderDetail();

                        await repository.Create(entity);

                        var record = await context.Set<PurchaseOrderDetail>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        context.Set<PurchaseOrderDetail>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.PurchaseOrderID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PurchaseOrderDetail>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        context.Set<PurchaseOrderDetail>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PurchaseOrderDetail());

                        var modifiedRecord = context.Set<PurchaseOrderDetail>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PurchaseOrderDetailRepository>> loggerMoc = PurchaseOrderDetailRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderDetailRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderDetailRepository(loggerMoc.Object, context);

                        PurchaseOrderDetail entity = new PurchaseOrderDetail();

                        context.Set<PurchaseOrderDetail>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.PurchaseOrderID);

                        PurchaseOrderDetail modifiedRecord = await context.Set<PurchaseOrderDetail>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>af1502323b3362d01e57152d4fdc5a19</Hash>
</Codenesium>*/