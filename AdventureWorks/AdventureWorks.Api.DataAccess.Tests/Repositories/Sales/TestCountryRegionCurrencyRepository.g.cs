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
	public partial class CountryRegionCurrencyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CountryRegionCurrencyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CountryRegionCurrencyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegionCurrency")]
	[Trait("Area", "Repositories")]
	public partial class CountryRegionCurrencyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);

			CountryRegionCurrency entity = new CountryRegionCurrency();
			context.Set<CountryRegionCurrency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);

			CountryRegionCurrency entity = new CountryRegionCurrency();
			context.Set<CountryRegionCurrency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);

			var entity = new CountryRegionCurrency();
			await repository.Create(entity);

			var record = await context.Set<CountryRegionCurrency>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);
			CountryRegionCurrency entity = new CountryRegionCurrency();
			context.Set<CountryRegionCurrency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			await repository.Update(record);

			var modifiedRecord = context.Set<CountryRegionCurrency>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);
			CountryRegionCurrency entity = new CountryRegionCurrency();
			context.Set<CountryRegionCurrency>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CountryRegionCurrency());

			var modifiedRecord = context.Set<CountryRegionCurrency>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CountryRegionCurrencyRepository>> loggerMoc = CountryRegionCurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionCurrencyRepositoryMoc.GetContext();
			var repository = new CountryRegionCurrencyRepository(loggerMoc.Object, context);
			CountryRegionCurrency entity = new CountryRegionCurrency();
			context.Set<CountryRegionCurrency>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CountryRegionCode);

			CountryRegionCurrency modifiedRecord = await context.Set<CountryRegionCurrency>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>176c79aa34c8cdedf03064341cc58156</Hash>
</Codenesium>*/