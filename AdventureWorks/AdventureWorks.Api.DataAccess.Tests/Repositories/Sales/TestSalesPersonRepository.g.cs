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
	public partial class SalesPersonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Repositories")]
	public partial class SalesPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			SalesPerson entity = new SalesPerson();
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			SalesPerson entity = new SalesPerson();
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);

			var entity = new SalesPerson();
			await repository.Create(entity);

			var record = await context.Set<SalesPerson>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesPerson());

			var modifiedRecord = context.Set<SalesPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesPersonRepository>> loggerMoc = SalesPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesPersonRepositoryMoc.GetContext();
			var repository = new SalesPersonRepository(loggerMoc.Object, context);
			SalesPerson entity = new SalesPerson();
			context.Set<SalesPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			SalesPerson modifiedRecord = await context.Set<SalesPerson>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>ede9070dd46150e466eda65cbe5844f9</Hash>
</Codenesium>*/