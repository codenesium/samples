using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CountryRegionRepository>> loggerMoc = CountryRegionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CountryRegionRepositoryMoc.GetContext();
			var repository = new CountryRegionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>9f9156a17cc774e80ad4dbc2a0114a1f</Hash>
</Codenesium>*/