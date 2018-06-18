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
        public partial class ProductModelRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProductModelRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProductModelRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModel")]
        [Trait("Area", "Repositories")]
        public partial class ProductModelRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        ProductModel entity = new ProductModel();

                        context.Set<ProductModel>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        ProductModel entity = new ProductModel();

                        context.Set<ProductModel>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        var entity = new ProductModel();

                        await repository.Create(entity);

                        var record = await context.Set<ProductModel>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        ProductModel entity = new ProductModel();

                        context.Set<ProductModel>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProductModel>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        ProductModel entity = new ProductModel();

                        context.Set<ProductModel>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProductModel());

                        var modifiedRecord = context.Set<ProductModel>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProductModelRepository>> loggerMoc = ProductModelRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelRepositoryMoc.GetContext();
                        var repository = new ProductModelRepository(loggerMoc.Object, context);

                        ProductModel entity = new ProductModel();

                        context.Set<ProductModel>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ProductModelID);

                        ProductModel modifiedRecord = await context.Set<ProductModel>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>94e6ebe204c68f3ee1375e9f37ff497a</Hash>
</Codenesium>*/