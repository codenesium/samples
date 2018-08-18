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
	public partial class CountryRegionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CountryRegionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CountryRegionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "Repositories")]
	public partial class CountryRegionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			CountryRegion entity = new CountryRegion();
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			CountryRegion entity = new CountryRegion();
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			var entity = new CountryRegion();
			await repository.Create(entity);

			var record = await context.Set<CountryRegion>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CountryRegionCode);

			await repository.Update(record);

			var modifiedRecord = context.Set<CountryRegion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CountryRegion());

			var modifiedRecord = context.Set<CountryRegion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);
			CountryRegion entity = new CountryRegion();
			context.Set<CountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CountryRegionCode);

			CountryRegion modifiedRecord = await context.Set<CountryRegion>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>6de9df794cef7d9e9bd6ff856f4fb97e</Hash>
</Codenesium>*/