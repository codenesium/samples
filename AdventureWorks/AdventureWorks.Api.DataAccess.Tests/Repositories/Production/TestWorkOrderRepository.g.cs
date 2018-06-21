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
        public partial class WorkOrderRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<WorkOrderRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<WorkOrderRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrder")]
        [Trait("Area", "Repositories")]
        public partial class WorkOrderRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);

                        WorkOrder entity = new WorkOrder();
                        context.Set<WorkOrder>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);

                        WorkOrder entity = new WorkOrder();
                        context.Set<WorkOrder>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.WorkOrderID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);

                        var entity = new WorkOrder();
                        await repository.Create(entity);

                        var record = await context.Set<WorkOrder>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);
                        WorkOrder entity = new WorkOrder();
                        context.Set<WorkOrder>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.WorkOrderID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<WorkOrder>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);
                        WorkOrder entity = new WorkOrder();
                        context.Set<WorkOrder>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new WorkOrder());

                        var modifiedRecord = context.Set<WorkOrder>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<WorkOrderRepository>> loggerMoc = WorkOrderRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkOrderRepositoryMoc.GetContext();
                        var repository = new WorkOrderRepository(loggerMoc.Object, context);
                        WorkOrder entity = new WorkOrder();
                        context.Set<WorkOrder>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.WorkOrderID);

                        WorkOrder modifiedRecord = await context.Set<WorkOrder>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>fb61df57b159e856ff215324e67944b9</Hash>
</Codenesium>*/