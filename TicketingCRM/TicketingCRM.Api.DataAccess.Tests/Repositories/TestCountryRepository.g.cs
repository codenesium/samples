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
	public partial class CountryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CountryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CountryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "Repositories")]
	public partial class CountryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);

			Country entity = new Country();
			context.Set<Country>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);

			Country entity = new Country();
			context.Set<Country>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);

			var entity = new Country();
			await repository.Create(entity);

			var record = await context.Set<Country>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);
			Country entity = new Country();
			context.Set<Country>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Country>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);
			Country entity = new Country();
			context.Set<Country>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Country());

			var modifiedRecord = context.Set<Country>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CountryRepository>> loggerMoc = CountryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRepositoryMoc.GetContext();
			var repository = new CountryRepository(loggerMoc.Object, context);
			Country entity = new Country();
			context.Set<Country>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Country modifiedRecord = await context.Set<Country>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>afa1ead66506c8e3a8747994d98065c9</Hash>
</Codenesium>*/