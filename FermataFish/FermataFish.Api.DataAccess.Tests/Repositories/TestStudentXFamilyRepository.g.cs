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
        public partial class StudentXFamilyRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<StudentXFamilyRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<StudentXFamilyRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "StudentXFamily")]
        [Trait("Area", "Repositories")]
        public partial class StudentXFamilyRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        StudentXFamily entity = new StudentXFamily();

                        context.Set<StudentXFamily>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        StudentXFamily entity = new StudentXFamily();

                        context.Set<StudentXFamily>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        var entity = new StudentXFamily();

                        await repository.Create(entity);

                        var record = await context.Set<StudentXFamily>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        StudentXFamily entity = new StudentXFamily();

                        context.Set<StudentXFamily>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<StudentXFamily>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        StudentXFamily entity = new StudentXFamily();

                        context.Set<StudentXFamily>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new StudentXFamily());

                        var modifiedRecord = context.Set<StudentXFamily>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<StudentXFamilyRepository>> loggerMoc = StudentXFamilyRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = StudentXFamilyRepositoryMoc.GetContext();
                        var repository = new StudentXFamilyRepository(loggerMoc.Object, context);

                        StudentXFamily entity = new StudentXFamily();

                        context.Set<StudentXFamily>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        StudentXFamily modifiedRecord = await context.Set<StudentXFamily>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>acc4a3b43975670066308ac06a6ac6a2</Hash>
</Codenesium>*/