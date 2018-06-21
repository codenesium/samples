using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class UsersRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<UsersRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<UsersRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Users")]
        [Trait("Area", "Repositories")]
        public partial class UsersRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);

                        Users entity = new Users();
                        context.Set<Users>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);

                        Users entity = new Users();
                        context.Set<Users>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);

                        var entity = new Users();
                        await repository.Create(entity);

                        var record = await context.Set<Users>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);
                        Users entity = new Users();
                        context.Set<Users>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Users>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);
                        Users entity = new Users();
                        context.Set<Users>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Users());

                        var modifiedRecord = context.Set<Users>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<UsersRepository>> loggerMoc = UsersRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = UsersRepositoryMoc.GetContext();
                        var repository = new UsersRepository(loggerMoc.Object, context);
                        Users entity = new Users();
                        context.Set<Users>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Users modifiedRecord = await context.Set<Users>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>ec34ee140582374c85080b4f77f5ac21</Hash>
</Codenesium>*/