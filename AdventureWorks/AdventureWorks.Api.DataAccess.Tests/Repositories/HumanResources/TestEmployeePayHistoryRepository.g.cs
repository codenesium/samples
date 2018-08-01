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
	public partial class EmployeePayHistoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EmployeePayHistoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EmployeePayHistoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EmployeePayHistory")]
	[Trait("Area", "Repositories")]
	public partial class EmployeePayHistoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);

			EmployeePayHistory entity = new EmployeePayHistory();
			context.Set<EmployeePayHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);

			EmployeePayHistory entity = new EmployeePayHistory();
			context.Set<EmployeePayHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);

			var entity = new EmployeePayHistory();
			await repository.Create(entity);

			var record = await context.Set<EmployeePayHistory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);
			EmployeePayHistory entity = new EmployeePayHistory();
			context.Set<EmployeePayHistory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<EmployeePayHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);
			EmployeePayHistory entity = new EmployeePayHistory();
			context.Set<EmployeePayHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EmployeePayHistory());

			var modifiedRecord = context.Set<EmployeePayHistory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EmployeePayHistoryRepository>> loggerMoc = EmployeePayHistoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EmployeePayHistoryRepositoryMoc.GetContext();
			var repository = new EmployeePayHistoryRepository(loggerMoc.Object, context);
			EmployeePayHistory entity = new EmployeePayHistory();
			context.Set<EmployeePayHistory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			EmployeePayHistory modifiedRecord = await context.Set<EmployeePayHistory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>94fe273a1264e821365a47d082a4b320</Hash>
</Codenesium>*/