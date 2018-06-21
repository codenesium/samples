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
        public partial class BusinessEntityContactRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<BusinessEntityContactRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<BusinessEntityContactRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityContact")]
        [Trait("Area", "Repositories")]
        public partial class BusinessEntityContactRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);

                        BusinessEntityContact entity = new BusinessEntityContact();
                        context.Set<BusinessEntityContact>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);

                        BusinessEntityContact entity = new BusinessEntityContact();
                        context.Set<BusinessEntityContact>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);

                        var entity = new BusinessEntityContact();
                        await repository.Create(entity);

                        var record = await context.Set<BusinessEntityContact>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);
                        BusinessEntityContact entity = new BusinessEntityContact();
                        context.Set<BusinessEntityContact>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<BusinessEntityContact>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);
                        BusinessEntityContact entity = new BusinessEntityContact();
                        context.Set<BusinessEntityContact>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new BusinessEntityContact());

                        var modifiedRecord = context.Set<BusinessEntityContact>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<BusinessEntityContactRepository>> loggerMoc = BusinessEntityContactRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityContactRepositoryMoc.GetContext();
                        var repository = new BusinessEntityContactRepository(loggerMoc.Object, context);
                        BusinessEntityContact entity = new BusinessEntityContact();
                        context.Set<BusinessEntityContact>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        BusinessEntityContact modifiedRecord = await context.Set<BusinessEntityContact>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>f45b37950ccde4402d7fc0abc92d089f</Hash>
</Codenesium>*/