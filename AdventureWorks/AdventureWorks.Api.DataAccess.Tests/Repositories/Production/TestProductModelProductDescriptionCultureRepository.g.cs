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
        public partial class ProductModelProductDescriptionCultureRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProductModelProductDescriptionCultureRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProductModelProductDescriptionCultureRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModelProductDescriptionCulture")]
        [Trait("Area", "Repositories")]
        public partial class ProductModelProductDescriptionCultureRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);

                        ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
                        context.Set<ProductModelProductDescriptionCulture>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);

                        ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
                        context.Set<ProductModelProductDescriptionCulture>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);

                        var entity = new ProductModelProductDescriptionCulture();
                        await repository.Create(entity);

                        var record = await context.Set<ProductModelProductDescriptionCulture>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);
                        ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
                        context.Set<ProductModelProductDescriptionCulture>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProductModelProductDescriptionCulture>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);
                        ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
                        context.Set<ProductModelProductDescriptionCulture>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProductModelProductDescriptionCulture());

                        var modifiedRecord = context.Set<ProductModelProductDescriptionCulture>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProductModelProductDescriptionCultureRepository>> loggerMoc = ProductModelProductDescriptionCultureRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelProductDescriptionCultureRepositoryMoc.GetContext();
                        var repository = new ProductModelProductDescriptionCultureRepository(loggerMoc.Object, context);
                        ProductModelProductDescriptionCulture entity = new ProductModelProductDescriptionCulture();
                        context.Set<ProductModelProductDescriptionCulture>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ProductModelID);

                        ProductModelProductDescriptionCulture modifiedRecord = await context.Set<ProductModelProductDescriptionCulture>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>fb7bcb3831763e9eee4aff7c8b9e1389</Hash>
</Codenesium>*/