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
        public partial class PersonCreditCardRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<PersonCreditCardRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<PersonCreditCardRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "Repositories")]
        public partial class PersonCreditCardRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);

                        PersonCreditCard entity = new PersonCreditCard();
                        context.Set<PersonCreditCard>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);

                        PersonCreditCard entity = new PersonCreditCard();
                        context.Set<PersonCreditCard>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);

                        var entity = new PersonCreditCard();
                        await repository.Create(entity);

                        var record = await context.Set<PersonCreditCard>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);
                        PersonCreditCard entity = new PersonCreditCard();
                        context.Set<PersonCreditCard>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<PersonCreditCard>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);
                        PersonCreditCard entity = new PersonCreditCard();
                        context.Set<PersonCreditCard>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new PersonCreditCard());

                        var modifiedRecord = context.Set<PersonCreditCard>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<PersonCreditCardRepository>> loggerMoc = PersonCreditCardRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = PersonCreditCardRepositoryMoc.GetContext();
                        var repository = new PersonCreditCardRepository(loggerMoc.Object, context);
                        PersonCreditCard entity = new PersonCreditCard();
                        context.Set<PersonCreditCard>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        PersonCreditCard modifiedRecord = await context.Set<PersonCreditCard>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>653bf92c0e126e7defc13a3a9f340f8b</Hash>
</Codenesium>*/