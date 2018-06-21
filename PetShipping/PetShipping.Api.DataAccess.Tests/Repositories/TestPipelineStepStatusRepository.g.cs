using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStepStatusRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PipelineStepStatusRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PipelineStepStatusRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "Repositories")]
        public partial class PipelineStepStatusRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);

                        PipelineStepStatus entity = new PipelineStepStatus();
                        context.Set<PipelineStepStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);

                        PipelineStepStatus entity = new PipelineStepStatus();
                        context.Set<PipelineStepStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);

                        var entity = new PipelineStepStatus();
                        await repository.Create(entity);

                        var record = await context.Set<PipelineStepStatus>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);
                        PipelineStepStatus entity = new PipelineStepStatus();
                        context.Set<PipelineStepStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PipelineStepStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);
                        PipelineStepStatus entity = new PipelineStepStatus();
                        context.Set<PipelineStepStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PipelineStepStatus());

                        var modifiedRecord = context.Set<PipelineStepStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PipelineStepStatusRepository>> loggerMoc = PipelineStepStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStatusRepositoryMoc.GetContext();
                        var repository = new PipelineStepStatusRepository(loggerMoc.Object, context);
                        PipelineStepStatus entity = new PipelineStepStatus();
                        context.Set<PipelineStepStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        PipelineStepStatus modifiedRecord = await context.Set<PipelineStepStatus>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>4bf1c94d3667a0f8764debb2808ca880</Hash>
</Codenesium>*/