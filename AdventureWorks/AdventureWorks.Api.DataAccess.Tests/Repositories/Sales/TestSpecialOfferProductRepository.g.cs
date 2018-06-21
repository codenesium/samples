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
        public partial class SpecialOfferProductRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<SpecialOfferProductRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<SpecialOfferProductRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "SpecialOfferProduct")]
        [Trait("Area", "Repositories")]
        public partial class SpecialOfferProductRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);

                        SpecialOfferProduct entity = new SpecialOfferProduct();
                        context.Set<SpecialOfferProduct>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);

                        SpecialOfferProduct entity = new SpecialOfferProduct();
                        context.Set<SpecialOfferProduct>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SpecialOfferID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);

                        var entity = new SpecialOfferProduct();
                        await repository.Create(entity);

                        var record = await context.Set<SpecialOfferProduct>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);
                        SpecialOfferProduct entity = new SpecialOfferProduct();
                        context.Set<SpecialOfferProduct>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.SpecialOfferID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<SpecialOfferProduct>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);
                        SpecialOfferProduct entity = new SpecialOfferProduct();
                        context.Set<SpecialOfferProduct>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new SpecialOfferProduct());

                        var modifiedRecord = context.Set<SpecialOfferProduct>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<SpecialOfferProductRepository>> loggerMoc = SpecialOfferProductRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = SpecialOfferProductRepositoryMoc.GetContext();
                        var repository = new SpecialOfferProductRepository(loggerMoc.Object, context);
                        SpecialOfferProduct entity = new SpecialOfferProduct();
                        context.Set<SpecialOfferProduct>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.SpecialOfferID);

                        SpecialOfferProduct modifiedRecord = await context.Set<SpecialOfferProduct>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>74b86d1a7a84f56bc7a7444e6ccf336f</Hash>
</Codenesium>*/