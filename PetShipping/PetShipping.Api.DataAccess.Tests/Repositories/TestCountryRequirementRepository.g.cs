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
        public partial class CountryRequirementRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<CountryRequirementRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<CountryRequirementRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRequirement")]
        [Trait("Area", "Repositories")]
        public partial class CountryRequirementRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);

                        CountryRequirement entity = new CountryRequirement();
                        context.Set<CountryRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);

                        CountryRequirement entity = new CountryRequirement();
                        context.Set<CountryRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);

                        var entity = new CountryRequirement();
                        await repository.Create(entity);

                        var record = await context.Set<CountryRequirement>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);
                        CountryRequirement entity = new CountryRequirement();
                        context.Set<CountryRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<CountryRequirement>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);
                        CountryRequirement entity = new CountryRequirement();
                        context.Set<CountryRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new CountryRequirement());

                        var modifiedRecord = context.Set<CountryRequirement>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<CountryRequirementRepository>> loggerMoc = CountryRequirementRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CountryRequirementRepositoryMoc.GetContext();
                        var repository = new CountryRequirementRepository(loggerMoc.Object, context);
                        CountryRequirement entity = new CountryRequirement();
                        context.Set<CountryRequirement>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        CountryRequirement modifiedRecord = await context.Set<CountryRequirement>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>e4c9b021f7ecd4d10ce3da446c368524</Hash>
</Codenesium>*/