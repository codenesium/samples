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
        public partial class TenantVariableRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TenantVariableRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TenantVariableRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "TenantVariable")]
        [Trait("Area", "Repositories")]
        public partial class TenantVariableRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        TenantVariable entity = new TenantVariable();

                        context.Set<TenantVariable>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        TenantVariable entity = new TenantVariable();

                        context.Set<TenantVariable>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        var entity = new TenantVariable();

                        await repository.Create(entity);

                        var record = await context.Set<TenantVariable>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        TenantVariable entity = new TenantVariable();

                        context.Set<TenantVariable>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<TenantVariable>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        TenantVariable entity = new TenantVariable();

                        context.Set<TenantVariable>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new TenantVariable());

                        var modifiedRecord = context.Set<TenantVariable>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TenantVariableRepository>> loggerMoc = TenantVariableRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TenantVariableRepositoryMoc.GetContext();
                        var repository = new TenantVariableRepository(loggerMoc.Object, context);

                        TenantVariable entity = new TenantVariable();

                        context.Set<TenantVariable>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        TenantVariable modifiedRecord = await context.Set<TenantVariable>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>33cc7cafbdcc8f20d94a215c58ee932e</Hash>
</Codenesium>*/