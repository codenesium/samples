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
        public partial class HandlerPipelineStepRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<HandlerPipelineStepRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<HandlerPipelineStepRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "Repositories")]
        public partial class HandlerPipelineStepRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);

                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        context.Set<HandlerPipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);

                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        context.Set<HandlerPipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);

                        var entity = new HandlerPipelineStep();
                        await repository.Create(entity);

                        var record = await context.Set<HandlerPipelineStep>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);
                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        context.Set<HandlerPipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<HandlerPipelineStep>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);
                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        context.Set<HandlerPipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new HandlerPipelineStep());

                        var modifiedRecord = context.Set<HandlerPipelineStep>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<HandlerPipelineStepRepository>> loggerMoc = HandlerPipelineStepRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = HandlerPipelineStepRepositoryMoc.GetContext();
                        var repository = new HandlerPipelineStepRepository(loggerMoc.Object, context);
                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        context.Set<HandlerPipelineStep>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        HandlerPipelineStep modifiedRecord = await context.Set<HandlerPipelineStep>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>060ca9fc411acb9cb6d66a063602e567</Hash>
</Codenesium>*/