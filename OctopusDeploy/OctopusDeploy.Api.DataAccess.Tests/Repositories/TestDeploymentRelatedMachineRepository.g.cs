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
        public partial class DeploymentRelatedMachineRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DeploymentRelatedMachineRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DeploymentRelatedMachineRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentRelatedMachine")]
        [Trait("Area", "Repositories")]
        public partial class DeploymentRelatedMachineRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        context.Set<DeploymentRelatedMachine>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        context.Set<DeploymentRelatedMachine>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        var entity = new DeploymentRelatedMachine();

                        await repository.Create(entity);

                        var record = await context.Set<DeploymentRelatedMachine>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        context.Set<DeploymentRelatedMachine>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<DeploymentRelatedMachine>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        context.Set<DeploymentRelatedMachine>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new DeploymentRelatedMachine());

                        var modifiedRecord = context.Set<DeploymentRelatedMachine>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DeploymentRelatedMachineRepository>> loggerMoc = DeploymentRelatedMachineRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DeploymentRelatedMachineRepositoryMoc.GetContext();
                        var repository = new DeploymentRelatedMachineRepository(loggerMoc.Object, context);

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        context.Set<DeploymentRelatedMachine>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        DeploymentRelatedMachine modifiedRecord = await context.Set<DeploymentRelatedMachine>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>29463c3c045d37c39e5289f03ae98dd7</Hash>
</Codenesium>*/