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
        public partial class LessonXStudentRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<LessonXStudentRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<LessonXStudentRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "Repositories")]
        public partial class LessonXStudentRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        LessonXStudent entity = new LessonXStudent();

                        context.Set<LessonXStudent>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        LessonXStudent entity = new LessonXStudent();

                        context.Set<LessonXStudent>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        var entity = new LessonXStudent();

                        await repository.Create(entity);

                        var record = await context.Set<LessonXStudent>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        LessonXStudent entity = new LessonXStudent();

                        context.Set<LessonXStudent>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<LessonXStudent>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        LessonXStudent entity = new LessonXStudent();

                        context.Set<LessonXStudent>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new LessonXStudent());

                        var modifiedRecord = context.Set<LessonXStudent>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<LessonXStudentRepository>> loggerMoc = LessonXStudentRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = LessonXStudentRepositoryMoc.GetContext();
                        var repository = new LessonXStudentRepository(loggerMoc.Object, context);

                        LessonXStudent entity = new LessonXStudent();

                        context.Set<LessonXStudent>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        LessonXStudent modifiedRecord = await context.Set<LessonXStudent>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>3c03a53f020b3008d5a21f69291a3de8</Hash>
</Codenesium>*/