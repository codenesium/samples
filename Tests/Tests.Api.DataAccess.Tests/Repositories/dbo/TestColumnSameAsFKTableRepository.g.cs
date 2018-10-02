using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
	public partial class ColumnSameAsFKTableRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ColumnSameAsFKTableRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ColumnSameAsFKTableRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Repositories")]
	public partial class ColumnSameAsFKTableRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			var entity = new ColumnSameAsFKTable();
			await repository.Create(entity);

			var record = await context.Set<ColumnSameAsFKTable>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ColumnSameAsFKTable>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ColumnSameAsFKTable());

			var modifiedRecord = context.Set<ColumnSameAsFKTable>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);
			ColumnSameAsFKTable entity = new ColumnSameAsFKTable();
			context.Set<ColumnSameAsFKTable>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ColumnSameAsFKTable modifiedRecord = await context.Set<ColumnSameAsFKTable>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>a2b4e349e7c377b8a662e3b8f0ebc386</Hash>
</Codenesium>*/