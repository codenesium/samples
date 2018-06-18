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
        public partial class AddressTypeRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<AddressTypeRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<AddressTypeRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "AddressType")]
        [Trait("Area", "Repositories")]
        public partial class AddressTypeRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        AddressType entity = new AddressType();

                        context.Set<AddressType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        AddressType entity = new AddressType();

                        context.Set<AddressType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.AddressTypeID);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        var entity = new AddressType();

                        await repository.Create(entity);

                        var record = await context.Set<AddressType>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        AddressType entity = new AddressType();

                        context.Set<AddressType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.AddressTypeID);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<AddressType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        AddressType entity = new AddressType();

                        context.Set<AddressType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new AddressType());

                        var modifiedRecord = context.Set<AddressType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
                        var repository = new AddressTypeRepository(loggerMoc.Object, context);

                        AddressType entity = new AddressType();

                        context.Set<AddressType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.AddressTypeID);

                        AddressType modifiedRecord = await context.Set<AddressType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ed6d63c328cf687d1bd8f5970e49b137</Hash>
</Codenesium>*/