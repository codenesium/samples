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
        public partial class BusinessEntityAddressRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<BusinessEntityAddressRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<BusinessEntityAddressRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "Repositories")]
        public partial class BusinessEntityAddressRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        BusinessEntityAddress entity = new BusinessEntityAddress();

                        context.Set<BusinessEntityAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        BusinessEntityAddress entity = new BusinessEntityAddress();

                        context.Set<BusinessEntityAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        var entity = new BusinessEntityAddress();

                        await repository.Create(entity);

                        var record = await context.Set<BusinessEntityAddress>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        BusinessEntityAddress entity = new BusinessEntityAddress();

                        context.Set<BusinessEntityAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<BusinessEntityAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        BusinessEntityAddress entity = new BusinessEntityAddress();

                        context.Set<BusinessEntityAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new BusinessEntityAddress());

                        var modifiedRecord = context.Set<BusinessEntityAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<BusinessEntityAddressRepository>> loggerMoc = BusinessEntityAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BusinessEntityAddressRepositoryMoc.GetContext();
                        var repository = new BusinessEntityAddressRepository(loggerMoc.Object, context);

                        BusinessEntityAddress entity = new BusinessEntityAddress();

                        context.Set<BusinessEntityAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        BusinessEntityAddress modifiedRecord = await context.Set<BusinessEntityAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>0297874b597b84f824cf5265afa13d71</Hash>
</Codenesium>*/