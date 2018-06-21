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
        public partial class PipelineStepStepRequirementRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PipelineStepStepRequirementRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PipelineStepStepRequirementRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepStepRequirement")]
        [Trait("Area", "Repositories")]
        public partial class PipelineStepStepRequirementRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);

                        PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
                        context.Set<PipelineStepStepRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);

                        PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
                        context.Set<PipelineStepStepRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);

                        var entity = new PipelineStepStepRequirement();
                        await repository.Create(entity);

                        var record = await context.Set<PipelineStepStepRequirement>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);
                        PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
                        context.Set<PipelineStepStepRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PipelineStepStepRequirement>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);
                        PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
                        context.Set<PipelineStepStepRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PipelineStepStepRequirement());

                        var modifiedRecord = context.Set<PipelineStepStepRequirement>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PipelineStepStepRequirementRepository>> loggerMoc = PipelineStepStepRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PipelineStepStepRequirementRepositoryMoc.GetContext();
                        var repository = new PipelineStepStepRequirementRepository(loggerMoc.Object, context);
                        PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
                        context.Set<PipelineStepStepRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        PipelineStepStepRequirement modifiedRecord = await context.Set<PipelineStepStepRequirement>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>c05ef2b3dfcd4a57824e7ed228b85e3a</Hash>
</Codenesium>*/