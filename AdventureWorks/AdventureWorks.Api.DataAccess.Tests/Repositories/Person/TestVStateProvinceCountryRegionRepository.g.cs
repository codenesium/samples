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
	public partial class VStateProvinceCountryRegionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VStateProvinceCountryRegionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VStateProvinceCountryRegionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "Repositories")]
	public partial class VStateProvinceCountryRegionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);

			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			context.Set<VStateProvinceCountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);

			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			context.Set<VStateProvinceCountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.StateProvinceID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);

			var entity = new VStateProvinceCountryRegion();
			await repository.Create(entity);

			var record = await context.Set<VStateProvinceCountryRegion>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);
			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			context.Set<VStateProvinceCountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.StateProvinceID);

			await repository.Update(record);

			var modifiedRecord = context.Set<VStateProvinceCountryRegion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);
			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			context.Set<VStateProvinceCountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VStateProvinceCountryRegion());

			var modifiedRecord = context.Set<VStateProvinceCountryRegion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VStateProvinceCountryRegionRepository>> loggerMoc = VStateProvinceCountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VStateProvinceCountryRegionRepositoryMoc.GetContext();
			var repository = new VStateProvinceCountryRegionRepository(loggerMoc.Object, context);
			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			context.Set<VStateProvinceCountryRegion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.StateProvinceID);

			VStateProvinceCountryRegion modifiedRecord = await context.Set<VStateProvinceCountryRegion>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>3abb80b3fb056f44ffc0fd1661b77132</Hash>
</Codenesium>*/