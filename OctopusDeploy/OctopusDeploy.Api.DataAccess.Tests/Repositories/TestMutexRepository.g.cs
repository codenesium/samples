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
        public partial class MutexRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<MutexRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<MutexRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Mutex")]
        [Trait("Area", "Repositories")]
        public partial class MutexRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);

                        Mutex entity = new Mutex();
                        context.Set<Mutex>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);

                        Mutex entity = new Mutex();
                        context.Set<Mutex>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);

                        var entity = new Mutex();
                        await repository.Create(entity);

                        var record = await context.Set<Mutex>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);
                        Mutex entity = new Mutex();
                        context.Set<Mutex>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Mutex>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);
                        Mutex entity = new Mutex();
                        context.Set<Mutex>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Mutex());

                        var modifiedRecord = context.Set<Mutex>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<MutexRepository>> loggerMoc = MutexRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = MutexRepositoryMoc.GetContext();
                        var repository = new MutexRepository(loggerMoc.Object, context);
                        Mutex entity = new Mutex();
                        context.Set<Mutex>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Mutex modifiedRecord = await context.Set<Mutex>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>37b1468f06baa5ebacfa24fb5d5dbbb5</Hash>
</Codenesium>*/