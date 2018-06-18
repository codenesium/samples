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
        public partial class ShoppingCartItemRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ShoppingCartItemRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ShoppingCartItemRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "Repositories")]
        public partial class ShoppingCartItemRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        ShoppingCartItem entity = new ShoppingCartItem();

                        context.Set<ShoppingCartItem>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        ShoppingCartItem entity = new ShoppingCartItem();

                        context.Set<ShoppingCartItem>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ShoppingCartItemID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        var entity = new ShoppingCartItem();

                        await repository.Create(entity);

                        var record = await context.Set<ShoppingCartItem>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        ShoppingCartItem entity = new ShoppingCartItem();

                        context.Set<ShoppingCartItem>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ShoppingCartItemID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ShoppingCartItem>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        ShoppingCartItem entity = new ShoppingCartItem();

                        context.Set<ShoppingCartItem>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ShoppingCartItem());

                        var modifiedRecord = context.Set<ShoppingCartItem>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
                        var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

                        ShoppingCartItem entity = new ShoppingCartItem();

                        context.Set<ShoppingCartItem>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ShoppingCartItemID);

                        ShoppingCartItem modifiedRecord = await context.Set<ShoppingCartItem>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>7182ae22ff360cd1f88a96fa26c74584</Hash>
</Codenesium>*/