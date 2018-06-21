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
        public partial class ProductInventoryRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProductInventoryRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProductInventoryRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProductInventory")]
        [Trait("Area", "Repositories")]
        public partial class ProductInventoryRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);

                        ProductInventory entity = new ProductInventory();
                        context.Set<ProductInventory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);

                        ProductInventory entity = new ProductInventory();
                        context.Set<ProductInventory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);

                        var entity = new ProductInventory();
                        await repository.Create(entity);

                        var record = await context.Set<ProductInventory>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);
                        ProductInventory entity = new ProductInventory();
                        context.Set<ProductInventory>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProductInventory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);
                        ProductInventory entity = new ProductInventory();
                        context.Set<ProductInventory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProductInventory());

                        var modifiedRecord = context.Set<ProductInventory>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProductInventoryRepository>> loggerMoc = ProductInventoryRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductInventoryRepositoryMoc.GetContext();
                        var repository = new ProductInventoryRepository(loggerMoc.Object, context);
                        ProductInventory entity = new ProductInventory();
                        context.Set<ProductInventory>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ProductID);

                        ProductInventory modifiedRecord = await context.Set<ProductInventory>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>24723a21291aff85e70a1225358d89b5</Hash>
</Codenesium>*/