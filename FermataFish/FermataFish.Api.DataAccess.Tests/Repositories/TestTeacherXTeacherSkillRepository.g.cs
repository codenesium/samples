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
        public partial class TeacherXTeacherSkillRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<TeacherXTeacherSkillRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<TeacherXTeacherSkillRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "TeacherXTeacherSkill")]
        [Trait("Area", "Repositories")]
        public partial class TeacherXTeacherSkillRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);

                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();
                        context.Set<TeacherXTeacherSkill>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);

                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();
                        context.Set<TeacherXTeacherSkill>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);

                        var entity = new TeacherXTeacherSkill();
                        await repository.Create(entity);

                        var record = await context.Set<TeacherXTeacherSkill>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);
                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();
                        context.Set<TeacherXTeacherSkill>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<TeacherXTeacherSkill>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);
                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();
                        context.Set<TeacherXTeacherSkill>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new TeacherXTeacherSkill());

                        var modifiedRecord = context.Set<TeacherXTeacherSkill>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<TeacherXTeacherSkillRepository>> loggerMoc = TeacherXTeacherSkillRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = TeacherXTeacherSkillRepositoryMoc.GetContext();
                        var repository = new TeacherXTeacherSkillRepository(loggerMoc.Object, context);
                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();
                        context.Set<TeacherXTeacherSkill>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        TeacherXTeacherSkill modifiedRecord = await context.Set<TeacherXTeacherSkill>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>9e022ecb9ced18d7bf6d73de36e36b50</Hash>
</Codenesium>*/