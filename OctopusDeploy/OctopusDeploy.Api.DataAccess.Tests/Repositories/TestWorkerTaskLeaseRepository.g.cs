using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class WorkerTaskLeaseRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<WorkerTaskLeaseRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<WorkerTaskLeaseRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "Repositories")]
        public partial class WorkerTaskLeaseRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        WorkerTaskLease entity = new WorkerTaskLease();

                        context.Set<WorkerTaskLease>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        WorkerTaskLease entity = new WorkerTaskLease();

                        context.Set<WorkerTaskLease>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        var entity = new WorkerTaskLease();

                        await repository.Create(entity);

                        var record = await context.Set<WorkerTaskLease>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        WorkerTaskLease entity = new WorkerTaskLease();

                        context.Set<WorkerTaskLease>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<WorkerTaskLease>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        WorkerTaskLease entity = new WorkerTaskLease();

                        context.Set<WorkerTaskLease>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new WorkerTaskLease());

                        var modifiedRecord = context.Set<WorkerTaskLease>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<WorkerTaskLeaseRepository>> loggerMoc = WorkerTaskLeaseRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = WorkerTaskLeaseRepositoryMoc.GetContext();
                        var repository = new WorkerTaskLeaseRepository(loggerMoc.Object, context);

                        WorkerTaskLease entity = new WorkerTaskLease();

                        context.Set<WorkerTaskLease>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        WorkerTaskLease modifiedRecord = await context.Set<WorkerTaskLease>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ccac2f059149cf66bd86e07cb259afc4</Hash>
</Codenesium>*/