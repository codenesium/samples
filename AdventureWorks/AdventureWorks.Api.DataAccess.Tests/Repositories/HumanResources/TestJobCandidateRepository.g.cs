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
        public partial class JobCandidateRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<JobCandidateRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<JobCandidateRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "Repositories")]
        public partial class JobCandidateRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);

                        JobCandidate entity = new JobCandidate();
                        context.Set<JobCandidate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);

                        JobCandidate entity = new JobCandidate();
                        context.Set<JobCandidate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.JobCandidateID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);

                        var entity = new JobCandidate();
                        await repository.Create(entity);

                        var record = await context.Set<JobCandidate>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);
                        JobCandidate entity = new JobCandidate();
                        context.Set<JobCandidate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.JobCandidateID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<JobCandidate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);
                        JobCandidate entity = new JobCandidate();
                        context.Set<JobCandidate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new JobCandidate());

                        var modifiedRecord = context.Set<JobCandidate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
                        var repository = new JobCandidateRepository(loggerMoc.Object, context);
                        JobCandidate entity = new JobCandidate();
                        context.Set<JobCandidate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.JobCandidateID);

                        JobCandidate modifiedRecord = await context.Set<JobCandidate>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>d3eb4b9b89135d8f83b19b2f4f351382</Hash>
</Codenesium>*/