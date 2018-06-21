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
        public partial class DeploymentEnvironmentRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DeploymentEnvironmentRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DeploymentEnvironmentRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "Repositories")]
        public partial class DeploymentEnvironmentRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);

                        DeploymentEnvironment entity = new DeploymentEnvironment();
                        context.Set<DeploymentEnvironment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);

                        DeploymentEnvironment entity = new DeploymentEnvironment();
                        context.Set<DeploymentEnvironment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);

                        var entity = new DeploymentEnvironment();
                        await repository.Create(entity);

                        var record = await context.Set<DeploymentEnvironment>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);
                        DeploymentEnvironment entity = new DeploymentEnvironment();
                        context.Set<DeploymentEnvironment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<DeploymentEnvironment>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);
                        DeploymentEnvironment entity = new DeploymentEnvironment();
                        context.Set<DeploymentEnvironment>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new DeploymentEnvironment());

                        var modifiedRecord = context.Set<DeploymentEnvironment>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DeploymentEnvironmentRepository>> loggerMoc = DeploymentEnvironmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentEnvironmentRepositoryMoc.GetContext();
                        var repository = new DeploymentEnvironmentRepository(loggerMoc.Object, context);
                        DeploymentEnvironment entity = new DeploymentEnvironment();
                        context.Set<DeploymentEnvironment>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        DeploymentEnvironment modifiedRecord = await context.Set<DeploymentEnvironment>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>76cc397138e683245cc97e08b4b005b0</Hash>
</Codenesium>*/