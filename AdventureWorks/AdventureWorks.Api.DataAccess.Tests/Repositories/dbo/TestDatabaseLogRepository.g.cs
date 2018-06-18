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
        public partial class DatabaseLogRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DatabaseLogRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DatabaseLogRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "Repositories")]
        public partial class DatabaseLogRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        DatabaseLog entity = new DatabaseLog();

                        context.Set<DatabaseLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        DatabaseLog entity = new DatabaseLog();

                        context.Set<DatabaseLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DatabaseLogID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        var entity = new DatabaseLog();

                        await repository.Create(entity);

                        var record = await context.Set<DatabaseLog>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        DatabaseLog entity = new DatabaseLog();

                        context.Set<DatabaseLog>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DatabaseLogID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<DatabaseLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        DatabaseLog entity = new DatabaseLog();

                        context.Set<DatabaseLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new DatabaseLog());

                        var modifiedRecord = context.Set<DatabaseLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DatabaseLogRepository>> loggerMoc = DatabaseLogRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DatabaseLogRepositoryMoc.GetContext();
                        var repository = new DatabaseLogRepository(loggerMoc.Object, context);

                        DatabaseLog entity = new DatabaseLog();

                        context.Set<DatabaseLog>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.DatabaseLogID);

                        DatabaseLog modifiedRecord = await context.Set<DatabaseLog>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>1e96e72d1de7da0c2f168ad5ce44cc44</Hash>
</Codenesium>*/