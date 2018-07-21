using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
        public partial class PersonRefRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PersonRefRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PersonRefRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PersonRef")]
        [Trait("Area", "Repositories")]
        public partial class PersonRefRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);

                        PersonRef entity = new PersonRef();
                        context.Set<PersonRef>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);

                        PersonRef entity = new PersonRef();
                        context.Set<PersonRef>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);

                        var entity = new PersonRef();
                        await repository.Create(entity);

                        var record = await context.Set<PersonRef>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);
                        PersonRef entity = new PersonRef();
                        context.Set<PersonRef>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PersonRef>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);
                        PersonRef entity = new PersonRef();
                        context.Set<PersonRef>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PersonRef());

                        var modifiedRecord = context.Set<PersonRef>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PersonRefRepository>> loggerMoc = PersonRefRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRefRepositoryMoc.GetContext();
                        var repository = new PersonRefRepository(loggerMoc.Object, context);
                        PersonRef entity = new PersonRef();
                        context.Set<PersonRef>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        PersonRef modifiedRecord = await context.Set<PersonRef>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>5f8c2b1606aecde36847b803d4d73ee6</Hash>
</Codenesium>*/