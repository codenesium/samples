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
        public partial class VariableSetRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<VariableSetRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<VariableSetRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "VariableSet")]
        [Trait("Area", "Repositories")]
        public partial class VariableSetRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        VariableSet entity = new VariableSet();

                        context.Set<VariableSet>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        VariableSet entity = new VariableSet();

                        context.Set<VariableSet>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        var entity = new VariableSet();

                        await repository.Create(entity);

                        var record = await context.Set<VariableSet>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        VariableSet entity = new VariableSet();

                        context.Set<VariableSet>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<VariableSet>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        VariableSet entity = new VariableSet();

                        context.Set<VariableSet>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new VariableSet());

                        var modifiedRecord = context.Set<VariableSet>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<VariableSetRepository>> loggerMoc = VariableSetRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VariableSetRepositoryMoc.GetContext();
                        var repository = new VariableSetRepository(loggerMoc.Object, context);

                        VariableSet entity = new VariableSet();

                        context.Set<VariableSet>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        VariableSet modifiedRecord = await context.Set<VariableSet>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>1c58d405bd9b2d945507841b757a6033</Hash>
</Codenesium>*/