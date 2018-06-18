using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FileServiceNS.Api.DataAccess
{
        public partial class BucketRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<BucketRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<BucketRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "Repositories")]
        public partial class BucketRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        Bucket entity = new Bucket();

                        context.Set<Bucket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        Bucket entity = new Bucket();

                        context.Set<Bucket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        var entity = new Bucket();

                        await repository.Create(entity);

                        var record = await context.Set<Bucket>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        Bucket entity = new Bucket();

                        context.Set<Bucket>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Bucket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        Bucket entity = new Bucket();

                        context.Set<Bucket>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Bucket());

                        var modifiedRecord = context.Set<Bucket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = BucketRepositoryMoc.GetContext();
                        var repository = new BucketRepository(loggerMoc.Object, context);

                        Bucket entity = new Bucket();

                        context.Set<Bucket>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Bucket modifiedRecord = await context.Set<Bucket>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>b8abfe9661f121c198b336684d5b1ab0</Hash>
</Codenesium>*/