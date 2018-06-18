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
        public partial class TicketRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TicketRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TicketRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Ticket")]
        [Trait("Area", "Repositories")]
        public partial class TicketRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        Ticket entity = new Ticket();

                        context.Set<Ticket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        Ticket entity = new Ticket();

                        context.Set<Ticket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        var entity = new Ticket();

                        await repository.Create(entity);

                        var record = await context.Set<Ticket>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        Ticket entity = new Ticket();

                        context.Set<Ticket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Ticket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        Ticket entity = new Ticket();

                        context.Set<Ticket>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Ticket());

                        var modifiedRecord = context.Set<Ticket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TicketRepository>> loggerMoc = TicketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketRepositoryMoc.GetContext();
                        var repository = new TicketRepository(loggerMoc.Object, context);

                        Ticket entity = new Ticket();

                        context.Set<Ticket>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Ticket modifiedRecord = await context.Set<Ticket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>99ad97c42b28d84a826e3eeb358f4f88</Hash>
</Codenesium>*/