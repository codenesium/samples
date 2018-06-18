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
        public partial class SaleTicketsRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<SaleTicketsRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<SaleTicketsRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "SaleTickets")]
        [Trait("Area", "Repositories")]
        public partial class SaleTicketsRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        SaleTickets entity = new SaleTickets();

                        context.Set<SaleTickets>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        SaleTickets entity = new SaleTickets();

                        context.Set<SaleTickets>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        var entity = new SaleTickets();

                        await repository.Create(entity);

                        var record = await context.Set<SaleTickets>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        SaleTickets entity = new SaleTickets();

                        context.Set<SaleTickets>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<SaleTickets>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        SaleTickets entity = new SaleTickets();

                        context.Set<SaleTickets>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new SaleTickets());

                        var modifiedRecord = context.Set<SaleTickets>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<SaleTicketsRepository>> loggerMoc = SaleTicketsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SaleTicketsRepositoryMoc.GetContext();
                        var repository = new SaleTicketsRepository(loggerMoc.Object, context);

                        SaleTickets entity = new SaleTickets();

                        context.Set<SaleTickets>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        SaleTickets modifiedRecord = await context.Set<SaleTickets>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>337ba9528aab010ea1e7a9726f5a2e21</Hash>
</Codenesium>*/