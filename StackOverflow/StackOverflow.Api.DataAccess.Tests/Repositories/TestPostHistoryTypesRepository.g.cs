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
        public partial class PostHistoryTypesRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PostHistoryTypesRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PostHistoryTypesRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "Repositories")]
        public partial class PostHistoryTypesRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);

                        PostHistoryTypes entity = new PostHistoryTypes();
                        context.Set<PostHistoryTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);

                        PostHistoryTypes entity = new PostHistoryTypes();
                        context.Set<PostHistoryTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);

                        var entity = new PostHistoryTypes();
                        await repository.Create(entity);

                        var record = await context.Set<PostHistoryTypes>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);
                        PostHistoryTypes entity = new PostHistoryTypes();
                        context.Set<PostHistoryTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PostHistoryTypes>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);
                        PostHistoryTypes entity = new PostHistoryTypes();
                        context.Set<PostHistoryTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PostHistoryTypes());

                        var modifiedRecord = context.Set<PostHistoryTypes>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PostHistoryTypesRepository>> loggerMoc = PostHistoryTypesRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PostHistoryTypesRepositoryMoc.GetContext();
                        var repository = new PostHistoryTypesRepository(loggerMoc.Object, context);
                        PostHistoryTypes entity = new PostHistoryTypes();
                        context.Set<PostHistoryTypes>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        PostHistoryTypes modifiedRecord = await context.Set<PostHistoryTypes>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>934c8af5077639f21ea4c78a1d07f0cb</Hash>
</Codenesium>*/