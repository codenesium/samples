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
        public partial class LessonStatusRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LessonStatusRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LessonStatusRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "Repositories")]
        public partial class LessonStatusRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);

                        LessonStatus entity = new LessonStatus();
                        context.Set<LessonStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);

                        LessonStatus entity = new LessonStatus();
                        context.Set<LessonStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);

                        var entity = new LessonStatus();
                        await repository.Create(entity);

                        var record = await context.Set<LessonStatus>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);
                        LessonStatus entity = new LessonStatus();
                        context.Set<LessonStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<LessonStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);
                        LessonStatus entity = new LessonStatus();
                        context.Set<LessonStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new LessonStatus());

                        var modifiedRecord = context.Set<LessonStatus>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LessonStatusRepository>> loggerMoc = LessonStatusRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonStatusRepositoryMoc.GetContext();
                        var repository = new LessonStatusRepository(loggerMoc.Object, context);
                        LessonStatus entity = new LessonStatus();
                        context.Set<LessonStatus>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        LessonStatus modifiedRecord = await context.Set<LessonStatus>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>e2ef834aad5951b1bbce4cfcb52e66ee</Hash>
</Codenesium>*/