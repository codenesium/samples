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
	public partial class IncludedColumnTestRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<IncludedColumnTestRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<IncludedColumnTestRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Repositories")]
	public partial class IncludedColumnTestRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			IncludedColumnTest entity = new IncludedColumnTest();
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			IncludedColumnTest entity = new IncludedColumnTest();
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			var entity = new IncludedColumnTest();
			await repository.Create(entity);

			var record = await context.Set<IncludedColumnTest>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<IncludedColumnTest>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new IncludedColumnTest());

			var modifiedRecord = context.Set<IncludedColumnTest>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);
			IncludedColumnTest entity = new IncludedColumnTest();
			context.Set<IncludedColumnTest>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			IncludedColumnTest modifiedRecord = await context.Set<IncludedColumnTest>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<IncludedColumnTestRepository>> loggerMoc = IncludedColumnTestRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = IncludedColumnTestRepositoryMoc.GetContext();
			var repository = new IncludedColumnTestRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>1a925057cb616b2f5c6f19ebd338e22c</Hash>
</Codenesium>*/