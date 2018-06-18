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
        public partial class BillOfMaterialsRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<BillOfMaterialsRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<BillOfMaterialsRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "Repositories")]
        public partial class BillOfMaterialsRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        BillOfMaterials entity = new BillOfMaterials();

                        context.Set<BillOfMaterials>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        BillOfMaterials entity = new BillOfMaterials();

                        context.Set<BillOfMaterials>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BillOfMaterialsID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        var entity = new BillOfMaterials();

                        await repository.Create(entity);

                        var record = await context.Set<BillOfMaterials>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        BillOfMaterials entity = new BillOfMaterials();

                        context.Set<BillOfMaterials>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BillOfMaterialsID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<BillOfMaterials>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        BillOfMaterials entity = new BillOfMaterials();

                        context.Set<BillOfMaterials>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new BillOfMaterials());

                        var modifiedRecord = context.Set<BillOfMaterials>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<BillOfMaterialsRepository>> loggerMoc = BillOfMaterialsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BillOfMaterialsRepositoryMoc.GetContext();
                        var repository = new BillOfMaterialsRepository(loggerMoc.Object, context);

                        BillOfMaterials entity = new BillOfMaterials();

                        context.Set<BillOfMaterials>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BillOfMaterialsID);

                        BillOfMaterials modifiedRecord = await context.Set<BillOfMaterials>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ef1bb431e353cc35a1c605ff51d2e715</Hash>
</Codenesium>*/