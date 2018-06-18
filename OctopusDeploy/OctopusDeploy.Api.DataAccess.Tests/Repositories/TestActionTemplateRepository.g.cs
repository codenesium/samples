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
        public partial class ActionTemplateRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ActionTemplateRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ActionTemplateRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "Repositories")]
        public partial class ActionTemplateRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        ActionTemplate entity = new ActionTemplate();

                        context.Set<ActionTemplate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        ActionTemplate entity = new ActionTemplate();

                        context.Set<ActionTemplate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        var entity = new ActionTemplate();

                        await repository.Create(entity);

                        var record = await context.Set<ActionTemplate>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        ActionTemplate entity = new ActionTemplate();

                        context.Set<ActionTemplate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ActionTemplate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        ActionTemplate entity = new ActionTemplate();

                        context.Set<ActionTemplate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ActionTemplate());

                        var modifiedRecord = context.Set<ActionTemplate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ActionTemplateRepository>> loggerMoc = ActionTemplateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ActionTemplateRepositoryMoc.GetContext();
                        var repository = new ActionTemplateRepository(loggerMoc.Object, context);

                        ActionTemplate entity = new ActionTemplate();

                        context.Set<ActionTemplate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        ActionTemplate modifiedRecord = await context.Set<ActionTemplate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>b637c9917f5aa4f0957f48e68e799f87</Hash>
</Codenesium>*/