using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class NuGetPackageRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<NuGetPackageRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<NuGetPackageRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "NuGetPackage")]
        [Trait("Area", "Repositories")]
        public partial class NuGetPackageRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);

                        NuGetPackage entity = new NuGetPackage();
                        context.Set<NuGetPackage>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);

                        NuGetPackage entity = new NuGetPackage();
                        context.Set<NuGetPackage>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);

                        var entity = new NuGetPackage();
                        await repository.Create(entity);

                        var record = await context.Set<NuGetPackage>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);
                        NuGetPackage entity = new NuGetPackage();
                        context.Set<NuGetPackage>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<NuGetPackage>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);
                        NuGetPackage entity = new NuGetPackage();
                        context.Set<NuGetPackage>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new NuGetPackage());

                        var modifiedRecord = context.Set<NuGetPackage>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<NuGetPackageRepository>> loggerMoc = NuGetPackageRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = NuGetPackageRepositoryMoc.GetContext();
                        var repository = new NuGetPackageRepository(loggerMoc.Object, context);
                        NuGetPackage entity = new NuGetPackage();
                        context.Set<NuGetPackage>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        NuGetPackage modifiedRecord = await context.Set<NuGetPackage>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>07b346b9d54c7c8791fb048ca92e1683</Hash>
</Codenesium>*/