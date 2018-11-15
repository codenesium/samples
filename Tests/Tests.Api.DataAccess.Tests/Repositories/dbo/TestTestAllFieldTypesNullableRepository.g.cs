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
	public partial class TestAllFieldTypesNullableRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TestAllFieldTypesNullableRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TestAllFieldTypesNullableRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Repositories")]
	public partial class TestAllFieldTypesNullableRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);

			TestAllFieldTypesNullable entity = new TestAllFieldTypesNullable();
			context.Set<TestAllFieldTypesNullable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);

			TestAllFieldTypesNullable entity = new TestAllFieldTypesNullable();
			context.Set<TestAllFieldTypesNullable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);

			var entity = new TestAllFieldTypesNullable();
			await repository.Create(entity);

			var record = await context.Set<TestAllFieldTypesNullable>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);
			TestAllFieldTypesNullable entity = new TestAllFieldTypesNullable();
			context.Set<TestAllFieldTypesNullable>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TestAllFieldTypesNullable>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);
			TestAllFieldTypesNullable entity = new TestAllFieldTypesNullable();
			context.Set<TestAllFieldTypesNullable>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TestAllFieldTypesNullable());

			var modifiedRecord = context.Set<TestAllFieldTypesNullable>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);
			TestAllFieldTypesNullable entity = new TestAllFieldTypesNullable();
			context.Set<TestAllFieldTypesNullable>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TestAllFieldTypesNullable modifiedRecord = await context.Set<TestAllFieldTypesNullable>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TestAllFieldTypesNullableRepository>> loggerMoc = TestAllFieldTypesNullableRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypesNullableRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypesNullableRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2c5f3a142191b8a19b4f0e8937b34d82</Hash>
</Codenesium>*/