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
        public partial class TeamRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TeamRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TeamRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Team")]
        [Trait("Area", "Repositories")]
        public partial class TeamRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);

                        Team entity = new Team();
                        context.Set<Team>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);

                        Team entity = new Team();
                        context.Set<Team>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);

                        var entity = new Team();
                        await repository.Create(entity);

                        var record = await context.Set<Team>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);
                        Team entity = new Team();
                        context.Set<Team>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Team>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);
                        Team entity = new Team();
                        context.Set<Team>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Team());

                        var modifiedRecord = context.Set<Team>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeamRepositoryMoc.GetContext();
                        var repository = new TeamRepository(loggerMoc.Object, context);
                        Team entity = new Team();
                        context.Set<Team>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Team modifiedRecord = await context.Set<Team>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>5d8ff5c8e616d13296970b7d49216efc</Hash>
</Codenesium>*/