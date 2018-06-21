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
        public partial class ProductModelIllustrationRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProductModelIllustrationRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProductModelIllustrationRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModelIllustration")]
        [Trait("Area", "Repositories")]
        public partial class ProductModelIllustrationRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);

                        ProductModelIllustration entity = new ProductModelIllustration();
                        context.Set<ProductModelIllustration>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);

                        ProductModelIllustration entity = new ProductModelIllustration();
                        context.Set<ProductModelIllustration>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);

                        var entity = new ProductModelIllustration();
                        await repository.Create(entity);

                        var record = await context.Set<ProductModelIllustration>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);
                        ProductModelIllustration entity = new ProductModelIllustration();
                        context.Set<ProductModelIllustration>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductModelID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProductModelIllustration>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);
                        ProductModelIllustration entity = new ProductModelIllustration();
                        context.Set<ProductModelIllustration>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProductModelIllustration());

                        var modifiedRecord = context.Set<ProductModelIllustration>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProductModelIllustrationRepository>> loggerMoc = ProductModelIllustrationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductModelIllustrationRepositoryMoc.GetContext();
                        var repository = new ProductModelIllustrationRepository(loggerMoc.Object, context);
                        ProductModelIllustration entity = new ProductModelIllustration();
                        context.Set<ProductModelIllustration>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ProductModelID);

                        ProductModelIllustration modifiedRecord = await context.Set<ProductModelIllustration>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>9448fddb4004083f0d278f4b76751efc</Hash>
</Codenesium>*/