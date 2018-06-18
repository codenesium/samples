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
        public partial class ProductReviewRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ProductReviewRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ProductReviewRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "Repositories")]
        public partial class ProductReviewRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        ProductReview entity = new ProductReview();

                        context.Set<ProductReview>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        ProductReview entity = new ProductReview();

                        context.Set<ProductReview>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductReviewID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        var entity = new ProductReview();

                        await repository.Create(entity);

                        var record = await context.Set<ProductReview>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        ProductReview entity = new ProductReview();

                        context.Set<ProductReview>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ProductReviewID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ProductReview>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        ProductReview entity = new ProductReview();

                        context.Set<ProductReview>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ProductReview());

                        var modifiedRecord = context.Set<ProductReview>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ProductReviewRepository>> loggerMoc = ProductReviewRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ProductReviewRepositoryMoc.GetContext();
                        var repository = new ProductReviewRepository(loggerMoc.Object, context);

                        ProductReview entity = new ProductReview();

                        context.Set<ProductReview>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ProductReviewID);

                        ProductReview modifiedRecord = await context.Set<ProductReview>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>4080e73a31ac9489be58d3b30c3d4396</Hash>
</Codenesium>*/