using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class TagsRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TagsRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TagsRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Tags")]
        [Trait("Area", "Repositories")]
        public partial class TagsRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);

                        Tags entity = new Tags();
                        context.Set<Tags>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);

                        Tags entity = new Tags();
                        context.Set<Tags>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);

                        var entity = new Tags();
                        await repository.Create(entity);

                        var record = await context.Set<Tags>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);
                        Tags entity = new Tags();
                        context.Set<Tags>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Tags>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);
                        Tags entity = new Tags();
                        context.Set<Tags>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Tags());

                        var modifiedRecord = context.Set<Tags>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TagsRepository>> loggerMoc = TagsRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TagsRepositoryMoc.GetContext();
                        var repository = new TagsRepository(loggerMoc.Object, context);
                        Tags entity = new Tags();
                        context.Set<Tags>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Tags modifiedRecord = await context.Set<Tags>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>d55679a035f6f3364a953f66f637eda6</Hash>
</Codenesium>*/