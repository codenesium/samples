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
        public partial class BillOfMaterialRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<BillOfMaterialRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<BillOfMaterialRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterial")]
        [Trait("Area", "Repositories")]
        public partial class BillOfMaterialRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

                        BillOfMaterial entity = new BillOfMaterial();
                        context.Set<BillOfMaterial>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

                        BillOfMaterial entity = new BillOfMaterial();
                        context.Set<BillOfMaterial>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BillOfMaterialsID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);

                        var entity = new BillOfMaterial();
                        await repository.Create(entity);

                        var record = await context.Set<BillOfMaterial>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
                        BillOfMaterial entity = new BillOfMaterial();
                        context.Set<BillOfMaterial>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BillOfMaterialsID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<BillOfMaterial>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
                        BillOfMaterial entity = new BillOfMaterial();
                        context.Set<BillOfMaterial>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new BillOfMaterial());

                        var modifiedRecord = context.Set<BillOfMaterial>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<BillOfMaterialRepository>> loggerMoc = BillOfMaterialRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialRepository(loggerMoc.Object, context);
                        BillOfMaterial entity = new BillOfMaterial();
                        context.Set<BillOfMaterial>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BillOfMaterialsID);

                        BillOfMaterial modifiedRecord = await context.Set<BillOfMaterial>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>14c2b312df7ce9731e161ae91aae1713</Hash>
</Codenesium>*/