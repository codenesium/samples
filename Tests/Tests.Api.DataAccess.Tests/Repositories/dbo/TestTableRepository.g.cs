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
	public partial class TableRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TableRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TableRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "Repositories")]
	public partial class TableRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);

			Table entity = new Table();
			context.Set<Table>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);

			Table entity = new Table();
			context.Set<Table>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);

			var entity = new Table();
			await repository.Create(entity);

			var record = await context.Set<Table>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);
			Table entity = new Table();
			context.Set<Table>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Table>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);
			Table entity = new Table();
			context.Set<Table>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Table());

			var modifiedRecord = context.Set<Table>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);
			Table entity = new Table();
			context.Set<Table>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Table modifiedRecord = await context.Set<Table>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TableRepository>> loggerMoc = TableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TableRepositoryMoc.GetContext();
			var repository = new TableRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>899650b631332a4b61422f6c92491ae1</Hash>
</Codenesium>*/