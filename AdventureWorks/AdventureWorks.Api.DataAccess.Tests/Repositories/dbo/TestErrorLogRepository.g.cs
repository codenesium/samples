using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ErrorLogRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ErrorLogRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ErrorLogRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ErrorLog")]
        [Trait("Area", "Repositories")]
        public partial class ErrorLogRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        ErrorLog entity = new ErrorLog();

                        context.Set<ErrorLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        ErrorLog entity = new ErrorLog();

                        context.Set<ErrorLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ErrorLogID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        var entity = new ErrorLog();

                        await repository.Create(entity);

                        var record = await context.Set<ErrorLog>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        ErrorLog entity = new ErrorLog();

                        context.Set<ErrorLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ErrorLogID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ErrorLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        ErrorLog entity = new ErrorLog();

                        context.Set<ErrorLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ErrorLog());

                        var modifiedRecord = context.Set<ErrorLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
                        var repository = new ErrorLogRepository(loggerMoc.Object, context);

                        ErrorLog entity = new ErrorLog();

                        context.Set<ErrorLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ErrorLogID);

                        ErrorLog modifiedRecord = await context.Set<ErrorLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>047dd35bbd4a7bb1e8ab6fade557d999</Hash>
</Codenesium>*/