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
        public partial class DeploymentHistoryRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DeploymentHistoryRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DeploymentHistoryRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentHistory")]
        [Trait("Area", "Repositories")]
        public partial class DeploymentHistoryRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);

                        DeploymentHistory entity = new DeploymentHistory();
                        context.Set<DeploymentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);

                        DeploymentHistory entity = new DeploymentHistory();
                        context.Set<DeploymentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DeploymentId);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);

                        var entity = new DeploymentHistory();
                        await repository.Create(entity);

                        var record = await context.Set<DeploymentHistory>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);
                        DeploymentHistory entity = new DeploymentHistory();
                        context.Set<DeploymentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DeploymentId);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<DeploymentHistory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);
                        DeploymentHistory entity = new DeploymentHistory();
                        context.Set<DeploymentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new DeploymentHistory());

                        var modifiedRecord = context.Set<DeploymentHistory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DeploymentHistoryRepository>> loggerMoc = DeploymentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentHistoryRepositoryMoc.GetContext();
                        var repository = new DeploymentHistoryRepository(loggerMoc.Object, context);
                        DeploymentHistory entity = new DeploymentHistory();
                        context.Set<DeploymentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.DeploymentId);

                        DeploymentHistory modifiedRecord = await context.Set<DeploymentHistory>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>86429062c70ec7eea8dd60230caab001</Hash>
</Codenesium>*/