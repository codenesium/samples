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
	public partial class SalesTaxRateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesTaxRateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTaxRateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Repositories")]
	public partial class SalesTaxRateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			var entity = new SalesTaxRate();
			await repository.Create(entity);

			var record = await context.Set<SalesTaxRate>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesTaxRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesTaxRate());

			var modifiedRecord = context.Set<SalesTaxRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesTaxRateID);

			SalesTaxRate modifiedRecord = await context.Set<SalesTaxRate>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>4e27f4ea36ffcf5e29febb815758651e</Hash>
</Codenesium>*/