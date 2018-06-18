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
        public partial class TransactionStatusRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TransactionStatusRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TransactionStatusRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionStatus")]
        [Trait("Area", "Repositories")]
        public partial class TransactionStatusRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        TransactionStatus entity = new TransactionStatus();

                        context.Set<TransactionStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        TransactionStatus entity = new TransactionStatus();

                        context.Set<TransactionStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        var entity = new TransactionStatus();

                        await repository.Create(entity);

                        var record = await context.Set<TransactionStatus>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        TransactionStatus entity = new TransactionStatus();

                        context.Set<TransactionStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<TransactionStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        TransactionStatus entity = new TransactionStatus();

                        context.Set<TransactionStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new TransactionStatus());

                        var modifiedRecord = context.Set<TransactionStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TransactionStatusRepository>> loggerMoc = TransactionStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TransactionStatusRepositoryMoc.GetContext();
                        var repository = new TransactionStatusRepository(loggerMoc.Object, context);

                        TransactionStatus entity = new TransactionStatus();

                        context.Set<TransactionStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        TransactionStatus modifiedRecord = await context.Set<TransactionStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>218213126f532a2bcaad3484f29197af</Hash>
</Codenesium>*/