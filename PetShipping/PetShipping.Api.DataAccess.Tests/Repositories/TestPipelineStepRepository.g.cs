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
        public partial class PipelineStepRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PipelineStepRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PipelineStepRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStep")]
        [Trait("Area", "Repositories")]
        public partial class PipelineStepRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        PipelineStep entity = new PipelineStep();

                        context.Set<PipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        PipelineStep entity = new PipelineStep();

                        context.Set<PipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        var entity = new PipelineStep();

                        await repository.Create(entity);

                        var record = await context.Set<PipelineStep>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        PipelineStep entity = new PipelineStep();

                        context.Set<PipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PipelineStep>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        PipelineStep entity = new PipelineStep();

                        context.Set<PipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PipelineStep());

                        var modifiedRecord = context.Set<PipelineStep>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PipelineStepRepository>> loggerMoc = PipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepRepositoryMoc.GetContext();
                        var repository = new PipelineStepRepository(loggerMoc.Object, context);

                        PipelineStep entity = new PipelineStep();

                        context.Set<PipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        PipelineStep modifiedRecord = await context.Set<PipelineStep>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ef6662313361872adabc6d7b518f707f</Hash>
</Codenesium>*/