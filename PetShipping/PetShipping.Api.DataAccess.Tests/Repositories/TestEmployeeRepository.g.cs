using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
        public partial class EmployeeRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<EmployeeRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<EmployeeRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Employee")]
        [Trait("Area", "Repositories")]
        public partial class EmployeeRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        Employee entity = new Employee();

                        context.Set<Employee>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        Employee entity = new Employee();

                        context.Set<Employee>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        var entity = new Employee();

                        await repository.Create(entity);

                        var record = await context.Set<Employee>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        Employee entity = new Employee();

                        context.Set<Employee>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Employee>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        Employee entity = new Employee();

                        context.Set<Employee>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Employee());

                        var modifiedRecord = context.Set<Employee>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<EmployeeRepository>> loggerMoc = EmployeeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmployeeRepositoryMoc.GetContext();
                        var repository = new EmployeeRepository(loggerMoc.Object, context);

                        Employee entity = new Employee();

                        context.Set<Employee>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Employee modifiedRecord = await context.Set<Employee>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>cc40f9ccd1a62c883a176bb0cc64b68c</Hash>
</Codenesium>*/