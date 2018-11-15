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
	public partial class TestAllFieldTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TestAllFieldTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TestAllFieldTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Repositories")]
	public partial class TestAllFieldTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			TestAllFieldType entity = new TestAllFieldType();
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			TestAllFieldType entity = new TestAllFieldType();
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			var entity = new TestAllFieldType();
			await repository.Create(entity);

			var record = await context.Set<TestAllFieldType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TestAllFieldType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TestAllFieldType());

			var modifiedRecord = context.Set<TestAllFieldType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);
			TestAllFieldType entity = new TestAllFieldType();
			context.Set<TestAllFieldType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TestAllFieldType modifiedRecord = await context.Set<TestAllFieldType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TestAllFieldTypeRepository>> loggerMoc = TestAllFieldTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TestAllFieldTypeRepositoryMoc.GetContext();
			var repository = new TestAllFieldTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>115cdbcc43b7b1426ba0ac71f385d48f</Hash>
</Codenesium>*/