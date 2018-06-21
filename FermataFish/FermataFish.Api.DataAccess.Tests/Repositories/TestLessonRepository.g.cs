using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FermataFishNS.Api.DataAccess
{
        public partial class LessonRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LessonRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LessonRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Lesson")]
        [Trait("Area", "Repositories")]
        public partial class LessonRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);

                        Lesson entity = new Lesson();
                        context.Set<Lesson>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);

                        Lesson entity = new Lesson();
                        context.Set<Lesson>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);

                        var entity = new Lesson();
                        await repository.Create(entity);

                        var record = await context.Set<Lesson>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);
                        Lesson entity = new Lesson();
                        context.Set<Lesson>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Lesson>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);
                        Lesson entity = new Lesson();
                        context.Set<Lesson>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Lesson());

                        var modifiedRecord = context.Set<Lesson>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LessonRepository>> loggerMoc = LessonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonRepositoryMoc.GetContext();
                        var repository = new LessonRepository(loggerMoc.Object, context);
                        Lesson entity = new Lesson();
                        context.Set<Lesson>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Lesson modifiedRecord = await context.Set<Lesson>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>908f6faaec2a355ff2a9d6b9d0506161</Hash>
</Codenesium>*/