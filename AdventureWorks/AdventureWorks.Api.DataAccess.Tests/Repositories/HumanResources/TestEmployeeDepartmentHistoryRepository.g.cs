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
        public partial class EmployeeDepartmentHistoryRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<EmployeeDepartmentHistoryRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<EmployeeDepartmentHistoryRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "EmployeeDepartmentHistory")]
        [Trait("Area", "Repositories")]
        public partial class EmployeeDepartmentHistoryRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);

                        EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
                        context.Set<EmployeeDepartmentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);

                        EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
                        context.Set<EmployeeDepartmentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);

                        var entity = new EmployeeDepartmentHistory();
                        await repository.Create(entity);

                        var record = await context.Set<EmployeeDepartmentHistory>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);
                        EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
                        context.Set<EmployeeDepartmentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<EmployeeDepartmentHistory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);
                        EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
                        context.Set<EmployeeDepartmentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new EmployeeDepartmentHistory());

                        var modifiedRecord = context.Set<EmployeeDepartmentHistory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<EmployeeDepartmentHistoryRepository>> loggerMoc = EmployeeDepartmentHistoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeDepartmentHistoryRepositoryMoc.GetContext();
                        var repository = new EmployeeDepartmentHistoryRepository(loggerMoc.Object, context);
                        EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
                        context.Set<EmployeeDepartmentHistory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        EmployeeDepartmentHistory modifiedRecord = await context.Set<EmployeeDepartmentHistory>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>2520139a99112932e98368b08729a18c</Hash>
</Codenesium>*/