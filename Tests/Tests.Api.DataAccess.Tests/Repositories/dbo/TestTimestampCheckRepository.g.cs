using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
        public partial class TimestampCheckRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TimestampCheckRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TimestampCheckRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "TimestampCheck")]
        [Trait("Area", "Repositories")]
        public partial class TimestampCheckRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);

                        TimestampCheck entity = new TimestampCheck();
                        context.Set<TimestampCheck>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);

                        TimestampCheck entity = new TimestampCheck();
                        context.Set<TimestampCheck>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);

                        var entity = new TimestampCheck();
                        await repository.Create(entity);

                        var record = await context.Set<TimestampCheck>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);
                        TimestampCheck entity = new TimestampCheck();
                        context.Set<TimestampCheck>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<TimestampCheck>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);
                        TimestampCheck entity = new TimestampCheck();
                        context.Set<TimestampCheck>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new TimestampCheck());

                        var modifiedRecord = context.Set<TimestampCheck>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TimestampCheckRepository>> loggerMoc = TimestampCheckRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TimestampCheckRepositoryMoc.GetContext();
                        var repository = new TimestampCheckRepository(loggerMoc.Object, context);
                        TimestampCheck entity = new TimestampCheck();
                        context.Set<TimestampCheck>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        TimestampCheck modifiedRecord = await context.Set<TimestampCheck>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>869937f8334b968f5425397ad5588d89</Hash>
</Codenesium>*/