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
        public partial class EmailAddressRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<EmailAddressRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<EmailAddressRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "EmailAddress")]
        [Trait("Area", "Repositories")]
        public partial class EmailAddressRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        EmailAddress entity = new EmailAddress();

                        context.Set<EmailAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        EmailAddress entity = new EmailAddress();

                        context.Set<EmailAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        var entity = new EmailAddress();

                        await repository.Create(entity);

                        var record = await context.Set<EmailAddress>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        EmailAddress entity = new EmailAddress();

                        context.Set<EmailAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.BusinessEntityID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<EmailAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        EmailAddress entity = new EmailAddress();

                        context.Set<EmailAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new EmailAddress());

                        var modifiedRecord = context.Set<EmailAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<EmailAddressRepository>> loggerMoc = EmailAddressRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = EmailAddressRepositoryMoc.GetContext();
                        var repository = new EmailAddressRepository(loggerMoc.Object, context);

                        EmailAddress entity = new EmailAddress();

                        context.Set<EmailAddress>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.BusinessEntityID);

                        EmailAddress modifiedRecord = await context.Set<EmailAddress>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>3b8f9f494622420ff76e9abe8f0a7a77</Hash>
</Codenesium>*/