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
        public partial class ContactTypeRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ContactTypeRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ContactTypeRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "ContactType")]
        [Trait("Area", "Repositories")]
        public partial class ContactTypeRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        ContactType entity = new ContactType();

                        context.Set<ContactType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        ContactType entity = new ContactType();

                        context.Set<ContactType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ContactTypeID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        var entity = new ContactType();

                        await repository.Create(entity);

                        var record = await context.Set<ContactType>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        ContactType entity = new ContactType();

                        context.Set<ContactType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.ContactTypeID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<ContactType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        ContactType entity = new ContactType();

                        context.Set<ContactType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new ContactType());

                        var modifiedRecord = context.Set<ContactType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ContactTypeRepository>> loggerMoc = ContactTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ContactTypeRepositoryMoc.GetContext();
                        var repository = new ContactTypeRepository(loggerMoc.Object, context);

                        ContactType entity = new ContactType();

                        context.Set<ContactType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.ContactTypeID);

                        ContactType modifiedRecord = await context.Set<ContactType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>834eaf6b362ba7e568e14d9185a59898</Hash>
</Codenesium>*/