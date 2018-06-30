using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class VenueRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<VenueRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<VenueRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Venue")]
        [Trait("Area", "Repositories")]
        public partial class VenueRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);

                        Venue entity = new Venue();
                        context.Set<Venue>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);

                        Venue entity = new Venue();
                        context.Set<Venue>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);

                        var entity = new Venue();
                        await repository.Create(entity);

                        var record = await context.Set<Venue>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);
                        Venue entity = new Venue();
                        context.Set<Venue>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Venue>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);
                        Venue entity = new Venue();
                        context.Set<Venue>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Venue());

                        var modifiedRecord = context.Set<Venue>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<VenueRepository>> loggerMoc = VenueRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = VenueRepositoryMoc.GetContext();
                        var repository = new VenueRepository(loggerMoc.Object, context);
                        Venue entity = new Venue();
                        context.Set<Venue>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Venue modifiedRecord = await context.Set<Venue>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>bcb5f900a0b8d2a0725e53707e310cea</Hash>
</Codenesium>*/