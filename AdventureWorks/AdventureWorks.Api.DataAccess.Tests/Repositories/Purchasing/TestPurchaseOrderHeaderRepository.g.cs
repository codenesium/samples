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
        public partial class PurchaseOrderHeaderRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PurchaseOrderHeaderRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PurchaseOrderHeaderRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PurchaseOrderHeader")]
        [Trait("Area", "Repositories")]
        public partial class PurchaseOrderHeaderRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        PurchaseOrderHeader entity = new PurchaseOrderHeader();

                        context.Set<PurchaseOrderHeader>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        PurchaseOrderHeader entity = new PurchaseOrderHeader();

                        context.Set<PurchaseOrderHeader>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.PurchaseOrderID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        var entity = new PurchaseOrderHeader();

                        await repository.Create(entity);

                        var record = await context.Set<PurchaseOrderHeader>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        PurchaseOrderHeader entity = new PurchaseOrderHeader();

                        context.Set<PurchaseOrderHeader>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.PurchaseOrderID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PurchaseOrderHeader>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        PurchaseOrderHeader entity = new PurchaseOrderHeader();

                        context.Set<PurchaseOrderHeader>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PurchaseOrderHeader());

                        var modifiedRecord = context.Set<PurchaseOrderHeader>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PurchaseOrderHeaderRepository>> loggerMoc = PurchaseOrderHeaderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PurchaseOrderHeaderRepositoryMoc.GetContext();
                        var repository = new PurchaseOrderHeaderRepository(loggerMoc.Object, context);

                        PurchaseOrderHeader entity = new PurchaseOrderHeader();

                        context.Set<PurchaseOrderHeader>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.PurchaseOrderID);

                        PurchaseOrderHeader modifiedRecord = await context.Set<PurchaseOrderHeader>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ba0ed4be94287bf68ec02bdf1a1eb385</Hash>
</Codenesium>*/