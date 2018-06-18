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
        public partial class TicketStatusRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TicketStatusRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TicketStatusRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "TicketStatus")]
        [Trait("Area", "Repositories")]
        public partial class TicketStatusRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        TicketStatus entity = new TicketStatus();

                        context.Set<TicketStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        TicketStatus entity = new TicketStatus();

                        context.Set<TicketStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        var entity = new TicketStatus();

                        await repository.Create(entity);

                        var record = await context.Set<TicketStatus>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        TicketStatus entity = new TicketStatus();

                        context.Set<TicketStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<TicketStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        TicketStatus entity = new TicketStatus();

                        context.Set<TicketStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new TicketStatus());

                        var modifiedRecord = context.Set<TicketStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TicketStatusRepository>> loggerMoc = TicketStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TicketStatusRepositoryMoc.GetContext();
                        var repository = new TicketStatusRepository(loggerMoc.Object, context);

                        TicketStatus entity = new TicketStatus();

                        context.Set<TicketStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        TicketStatus modifiedRecord = await context.Set<TicketStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>1f5f0187faa5eb51d48a51e2bfa36624</Hash>
</Codenesium>*/