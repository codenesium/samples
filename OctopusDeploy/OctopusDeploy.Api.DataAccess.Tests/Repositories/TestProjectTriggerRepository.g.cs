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
        public partial class ProjectTriggerRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProjectTriggerRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProjectTriggerRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "Repositories")]
        public partial class ProjectTriggerRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        ProjectTrigger entity = new ProjectTrigger();

                        context.Set<ProjectTrigger>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        ProjectTrigger entity = new ProjectTrigger();

                        context.Set<ProjectTrigger>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        var entity = new ProjectTrigger();

                        await repository.Create(entity);

                        var record = await context.Set<ProjectTrigger>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        ProjectTrigger entity = new ProjectTrigger();

                        context.Set<ProjectTrigger>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProjectTrigger>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        ProjectTrigger entity = new ProjectTrigger();

                        context.Set<ProjectTrigger>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProjectTrigger());

                        var modifiedRecord = context.Set<ProjectTrigger>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProjectTriggerRepository>> loggerMoc = ProjectTriggerRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProjectTriggerRepositoryMoc.GetContext();
                        var repository = new ProjectTriggerRepository(loggerMoc.Object, context);

                        ProjectTrigger entity = new ProjectTrigger();

                        context.Set<ProjectTrigger>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        ProjectTrigger modifiedRecord = await context.Set<ProjectTrigger>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>66c03229b23cff6dc99952d85831b6a0</Hash>
</Codenesium>*/