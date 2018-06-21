using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class CityRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<CityRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<CityRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "City")]
        [Trait("Area", "Repositories")]
        public partial class CityRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);

                        City entity = new City();
                        context.Set<City>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);

                        City entity = new City();
                        context.Set<City>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);

                        var entity = new City();
                        await repository.Create(entity);

                        var record = await context.Set<City>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);
                        City entity = new City();
                        context.Set<City>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<City>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);
                        City entity = new City();
                        context.Set<City>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new City());

                        var modifiedRecord = context.Set<City>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<CityRepository>> loggerMoc = CityRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CityRepositoryMoc.GetContext();
                        var repository = new CityRepository(loggerMoc.Object, context);
                        City entity = new City();
                        context.Set<City>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        City modifiedRecord = await context.Set<City>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>88e4fc7326bfd3d530386932fe27eafe</Hash>
</Codenesium>*/