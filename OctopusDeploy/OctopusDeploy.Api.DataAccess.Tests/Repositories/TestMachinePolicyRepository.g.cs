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
        public partial class MachinePolicyRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<MachinePolicyRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<MachinePolicyRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "MachinePolicy")]
        [Trait("Area", "Repositories")]
        public partial class MachinePolicyRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);

                        MachinePolicy entity = new MachinePolicy();
                        context.Set<MachinePolicy>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);

                        MachinePolicy entity = new MachinePolicy();
                        context.Set<MachinePolicy>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);

                        var entity = new MachinePolicy();
                        await repository.Create(entity);

                        var record = await context.Set<MachinePolicy>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);
                        MachinePolicy entity = new MachinePolicy();
                        context.Set<MachinePolicy>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<MachinePolicy>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);
                        MachinePolicy entity = new MachinePolicy();
                        context.Set<MachinePolicy>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new MachinePolicy());

                        var modifiedRecord = context.Set<MachinePolicy>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<MachinePolicyRepository>> loggerMoc = MachinePolicyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MachinePolicyRepositoryMoc.GetContext();
                        var repository = new MachinePolicyRepository(loggerMoc.Object, context);
                        MachinePolicy entity = new MachinePolicy();
                        context.Set<MachinePolicy>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        MachinePolicy modifiedRecord = await context.Set<MachinePolicy>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>22c8939a1254326f52bd5a7a22068358</Hash>
</Codenesium>*/