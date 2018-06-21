using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PersonRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PersonRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PersonRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Person")]
        [Trait("Area", "Repositories")]
        public partial class PersonRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);

                        Person entity = new Person();
                        context.Set<Person>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);

                        Person entity = new Person();
                        context.Set<Person>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);

                        var entity = new Person();
                        await repository.Create(entity);

                        var record = await context.Set<Person>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);
                        Person entity = new Person();
                        context.Set<Person>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Person>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);
                        Person entity = new Person();
                        context.Set<Person>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Person());

                        var modifiedRecord = context.Set<Person>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PersonRepository>> loggerMoc = PersonRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonRepositoryMoc.GetContext();
                        var repository = new PersonRepository(loggerMoc.Object, context);
                        Person entity = new Person();
                        context.Set<Person>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        Person modifiedRecord = await context.Set<Person>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>5b4f42dc0d7c2b551e7f4df94a72913c</Hash>
</Codenesium>*/