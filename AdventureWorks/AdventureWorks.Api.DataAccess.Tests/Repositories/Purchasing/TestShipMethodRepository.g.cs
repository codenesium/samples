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
        public partial class ShipMethodRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ShipMethodRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ShipMethodRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ShipMethod")]
        [Trait("Area", "Repositories")]
        public partial class ShipMethodRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);

                        ShipMethod entity = new ShipMethod();
                        context.Set<ShipMethod>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);

                        ShipMethod entity = new ShipMethod();
                        context.Set<ShipMethod>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ShipMethodID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);

                        var entity = new ShipMethod();
                        await repository.Create(entity);

                        var record = await context.Set<ShipMethod>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);
                        ShipMethod entity = new ShipMethod();
                        context.Set<ShipMethod>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ShipMethodID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ShipMethod>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);
                        ShipMethod entity = new ShipMethod();
                        context.Set<ShipMethod>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ShipMethod());

                        var modifiedRecord = context.Set<ShipMethod>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ShipMethodRepository>> loggerMoc = ShipMethodRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ShipMethodRepositoryMoc.GetContext();
                        var repository = new ShipMethodRepository(loggerMoc.Object, context);
                        ShipMethod entity = new ShipMethod();
                        context.Set<ShipMethod>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ShipMethodID);

                        ShipMethod modifiedRecord = await context.Set<ShipMethod>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>d275eac36cd6e39cb358f8326b2e1eee</Hash>
</Codenesium>*/