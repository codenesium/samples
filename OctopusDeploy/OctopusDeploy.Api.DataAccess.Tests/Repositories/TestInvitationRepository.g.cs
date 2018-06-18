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
        public partial class InvitationRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<InvitationRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<InvitationRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Invitation")]
        [Trait("Area", "Repositories")]
        public partial class InvitationRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        Invitation entity = new Invitation();

                        context.Set<Invitation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        Invitation entity = new Invitation();

                        context.Set<Invitation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        var entity = new Invitation();

                        await repository.Create(entity);

                        var record = await context.Set<Invitation>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        Invitation entity = new Invitation();

                        context.Set<Invitation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Invitation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        Invitation entity = new Invitation();

                        context.Set<Invitation>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Invitation());

                        var modifiedRecord = context.Set<Invitation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<InvitationRepository>> loggerMoc = InvitationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = InvitationRepositoryMoc.GetContext();
                        var repository = new InvitationRepository(loggerMoc.Object, context);

                        Invitation entity = new Invitation();

                        context.Set<Invitation>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Invitation modifiedRecord = await context.Set<Invitation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>330c71e141587ae1e3c6e0e3040366b7</Hash>
</Codenesium>*/