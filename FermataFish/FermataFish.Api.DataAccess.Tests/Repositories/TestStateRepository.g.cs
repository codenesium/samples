using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FermataFishNS.Api.DataAccess
{
        public partial class StateRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<StateRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<StateRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "State")]
        [Trait("Area", "Repositories")]
        public partial class StateRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        State entity = new State();

                        context.Set<State>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        State entity = new State();

                        context.Set<State>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        var entity = new State();

                        await repository.Create(entity);

                        var record = await context.Set<State>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        State entity = new State();

                        context.Set<State>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<State>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        State entity = new State();

                        context.Set<State>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new State());

                        var modifiedRecord = context.Set<State>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<StateRepository>> loggerMoc = StateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StateRepositoryMoc.GetContext();
                        var repository = new StateRepository(loggerMoc.Object, context);

                        State entity = new State();

                        context.Set<State>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        State modifiedRecord = await context.Set<State>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>1b686cd9ca29ae78ea1b92c559034f4b</Hash>
</Codenesium>*/