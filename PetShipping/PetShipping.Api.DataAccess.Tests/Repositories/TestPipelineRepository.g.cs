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
        public partial class PipelineRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PipelineRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PipelineRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Pipeline")]
        [Trait("Area", "Repositories")]
        public partial class PipelineRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);

                        Pipeline entity = new Pipeline();
                        context.Set<Pipeline>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);

                        Pipeline entity = new Pipeline();
                        context.Set<Pipeline>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);

                        var entity = new Pipeline();
                        await repository.Create(entity);

                        var record = await context.Set<Pipeline>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);
                        Pipeline entity = new Pipeline();
                        context.Set<Pipeline>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Pipeline>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);
                        Pipeline entity = new Pipeline();
                        context.Set<Pipeline>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Pipeline());

                        var modifiedRecord = context.Set<Pipeline>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
                        var repository = new PipelineRepository(loggerMoc.Object, context);
                        Pipeline entity = new Pipeline();
                        context.Set<Pipeline>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Pipeline modifiedRecord = await context.Set<Pipeline>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>60137578ba861c3d3e5133a32d4b4628</Hash>
</Codenesium>*/