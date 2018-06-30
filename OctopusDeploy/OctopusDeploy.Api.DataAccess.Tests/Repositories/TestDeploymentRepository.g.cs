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
        public partial class DeploymentRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DeploymentRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DeploymentRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Deployment")]
        [Trait("Area", "Repositories")]
        public partial class DeploymentRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);

                        Deployment entity = new Deployment();
                        context.Set<Deployment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);

                        Deployment entity = new Deployment();
                        context.Set<Deployment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);

                        var entity = new Deployment();
                        await repository.Create(entity);

                        var record = await context.Set<Deployment>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);
                        Deployment entity = new Deployment();
                        context.Set<Deployment>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Deployment>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);
                        Deployment entity = new Deployment();
                        context.Set<Deployment>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Deployment());

                        var modifiedRecord = context.Set<Deployment>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DeploymentRepository>> loggerMoc = DeploymentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRepositoryMoc.GetContext();
                        var repository = new DeploymentRepository(loggerMoc.Object, context);
                        Deployment entity = new Deployment();
                        context.Set<Deployment>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Deployment modifiedRecord = await context.Set<Deployment>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>18ee2aeb3fff2db1d5f059da94bc946d</Hash>
</Codenesium>*/