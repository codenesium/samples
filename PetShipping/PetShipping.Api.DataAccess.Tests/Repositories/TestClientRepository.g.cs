using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
        public partial class ClientRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<ClientRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<ClientRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Client")]
        [Trait("Area", "Repositories")]
        public partial class ClientRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        Client entity = new Client();

                        context.Set<Client>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        Client entity = new Client();

                        context.Set<Client>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        var entity = new Client();

                        await repository.Create(entity);

                        var record = await context.Set<Client>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        Client entity = new Client();

                        context.Set<Client>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Client>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        Client entity = new Client();

                        context.Set<Client>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Client());

                        var modifiedRecord = context.Set<Client>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<ClientRepository>> loggerMoc = ClientRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = ClientRepositoryMoc.GetContext();
                        var repository = new ClientRepository(loggerMoc.Object, context);

                        Client entity = new Client();

                        context.Set<Client>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Client modifiedRecord = await context.Set<Client>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>09f8880f7832d15dca230e23d74c36fd</Hash>
</Codenesium>*/