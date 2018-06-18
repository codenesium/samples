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
        public partial class DepartmentRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<DepartmentRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<DepartmentRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Department")]
        [Trait("Area", "Repositories")]
        public partial class DepartmentRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        Department entity = new Department();

                        context.Set<Department>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        Department entity = new Department();

                        context.Set<Department>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DepartmentID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        var entity = new Department();

                        await repository.Create(entity);

                        var record = await context.Set<Department>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        Department entity = new Department();

                        context.Set<Department>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.DepartmentID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Department>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        Department entity = new Department();

                        context.Set<Department>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Department());

                        var modifiedRecord = context.Set<Department>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<DepartmentRepository>> loggerMoc = DepartmentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = DepartmentRepositoryMoc.GetContext();
                        var repository = new DepartmentRepository(loggerMoc.Object, context);

                        Department entity = new Department();

                        context.Set<Department>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.DepartmentID);

                        Department modifiedRecord = await context.Set<Department>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>b3684aaab27df31a6bbb89be448d9e41</Hash>
</Codenesium>*/