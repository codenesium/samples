using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ColumnSameAsFKTableRepository>> loggerMoc = ColumnSameAsFKTableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ColumnSameAsFKTableRepositoryMoc.GetContext();
			var repository = new ColumnSameAsFKTableRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>48d90d83dfbdb7ee75afc4a7fe151f52</Hash>
</Codenesium>*/