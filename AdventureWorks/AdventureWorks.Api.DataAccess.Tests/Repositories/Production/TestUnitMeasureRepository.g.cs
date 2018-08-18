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
	public partial class UnitMeasureRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<UnitMeasureRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UnitMeasureRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Repositories")]
	public partial class UnitMeasureRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			UnitMeasure entity = new UnitMeasure();
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			UnitMeasure entity = new UnitMeasure();
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UnitMeasureCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);

			var entity = new UnitMeasure();
			await repository.Create(entity);

			var record = await context.Set<UnitMeasure>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.UnitMeasureCode);

			await repository.Update(record);

			var modifiedRecord = context.Set<UnitMeasure>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new UnitMeasure());

			var modifiedRecord = context.Set<UnitMeasure>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<UnitMeasureRepository>> loggerMoc = UnitMeasureRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UnitMeasureRepositoryMoc.GetContext();
			var repository = new UnitMeasureRepository(loggerMoc.Object, context);
			UnitMeasure entity = new UnitMeasure();
			context.Set<UnitMeasure>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.UnitMeasureCode);

			UnitMeasure modifiedRecord = await context.Set<UnitMeasure>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f35aaf4cc8876e1e724cb9d0baa6b58a</Hash>
</Codenesium>*/