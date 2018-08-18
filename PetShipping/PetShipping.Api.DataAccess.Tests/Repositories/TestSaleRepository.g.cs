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
	public partial class SaleRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SaleRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SaleRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "Repositories")]
	public partial class SaleRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);

			Sale entity = new Sale();
			context.Set<Sale>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);

			Sale entity = new Sale();
			context.Set<Sale>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);

			var entity = new Sale();
			await repository.Create(entity);

			var record = await context.Set<Sale>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);
			Sale entity = new Sale();
			context.Set<Sale>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Sale>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);
			Sale entity = new Sale();
			context.Set<Sale>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Sale());

			var modifiedRecord = context.Set<Sale>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SaleRepository>> loggerMoc = SaleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SaleRepositoryMoc.GetContext();
			var repository = new SaleRepository(loggerMoc.Object, context);
			Sale entity = new Sale();
			context.Set<Sale>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Sale modifiedRecord = await context.Set<Sale>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>21285e1a6db93cc02aea2686e50eb50a</Hash>
</Codenesium>*/