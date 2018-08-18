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
	public partial class SalesOrderHeaderRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesOrderHeaderRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesOrderHeaderRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Repositories")]
	public partial class SalesOrderHeaderRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			SalesOrderHeader entity = new SalesOrderHeader();
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			SalesOrderHeader entity = new SalesOrderHeader();
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);

			var entity = new SalesOrderHeader();
			await repository.Create(entity);

			var record = await context.Set<SalesOrderHeader>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesOrderID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesOrderHeader>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesOrderHeader());

			var modifiedRecord = context.Set<SalesOrderHeader>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SalesOrderHeaderRepository>> loggerMoc = SalesOrderHeaderRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesOrderHeaderRepositoryMoc.GetContext();
			var repository = new SalesOrderHeaderRepository(loggerMoc.Object, context);
			SalesOrderHeader entity = new SalesOrderHeader();
			context.Set<SalesOrderHeader>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesOrderID);

			SalesOrderHeader modifiedRecord = await context.Set<SalesOrderHeader>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>45c6f2e104842aa4444998aa10f7ebfc</Hash>
</Codenesium>*/