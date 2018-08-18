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
	public partial class BusinessEntityRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<BusinessEntityRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BusinessEntityRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "Repositories")]
	public partial class BusinessEntityRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			var entity = new BusinessEntity();
			await repository.Create(entity);

			var record = await context.Set<BusinessEntity>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<BusinessEntity>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new BusinessEntity());

			var modifiedRecord = context.Set<BusinessEntity>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			BusinessEntity modifiedRecord = await context.Set<BusinessEntity>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f9415d9c3f50a36519944f8d557864d0</Hash>
</Codenesium>*/