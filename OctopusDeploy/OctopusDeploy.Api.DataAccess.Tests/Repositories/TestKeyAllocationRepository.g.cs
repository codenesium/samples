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
        public partial class KeyAllocationRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<KeyAllocationRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<KeyAllocationRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "KeyAllocation")]
        [Trait("Area", "Repositories")]
        public partial class KeyAllocationRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        KeyAllocation entity = new KeyAllocation();

                        context.Set<KeyAllocation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        KeyAllocation entity = new KeyAllocation();

                        context.Set<KeyAllocation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.CollectionName);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        var entity = new KeyAllocation();

                        await repository.Create(entity);

                        var record = await context.Set<KeyAllocation>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        KeyAllocation entity = new KeyAllocation();

                        context.Set<KeyAllocation>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.CollectionName);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<KeyAllocation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        KeyAllocation entity = new KeyAllocation();

                        context.Set<KeyAllocation>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new KeyAllocation());

                        var modifiedRecord = context.Set<KeyAllocation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<KeyAllocationRepository>> loggerMoc = KeyAllocationRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = KeyAllocationRepositoryMoc.GetContext();
                        var repository = new KeyAllocationRepository(loggerMoc.Object, context);

                        KeyAllocation entity = new KeyAllocation();

                        context.Set<KeyAllocation>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.CollectionName);

                        KeyAllocation modifiedRecord = await context.Set<KeyAllocation>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>b7ce7fa397376d5db0135736c9f8e1d8</Hash>
</Codenesium>*/