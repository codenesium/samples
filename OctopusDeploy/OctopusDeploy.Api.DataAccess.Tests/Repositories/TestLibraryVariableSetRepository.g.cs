using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class LibraryVariableSetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LibraryVariableSetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LibraryVariableSetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LibraryVariableSet")]
	[Trait("Area", "Repositories")]
	public partial class LibraryVariableSetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);

			LibraryVariableSet entity = new LibraryVariableSet();
			context.Set<LibraryVariableSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);

			LibraryVariableSet entity = new LibraryVariableSet();
			context.Set<LibraryVariableSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);

			var entity = new LibraryVariableSet();
			await repository.Create(entity);

			var record = await context.Set<LibraryVariableSet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);
			LibraryVariableSet entity = new LibraryVariableSet();
			context.Set<LibraryVariableSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<LibraryVariableSet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);
			LibraryVariableSet entity = new LibraryVariableSet();
			context.Set<LibraryVariableSet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new LibraryVariableSet());

			var modifiedRecord = context.Set<LibraryVariableSet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LibraryVariableSetRepository>> loggerMoc = LibraryVariableSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LibraryVariableSetRepositoryMoc.GetContext();
			var repository = new LibraryVariableSetRepository(loggerMoc.Object, context);
			LibraryVariableSet entity = new LibraryVariableSet();
			context.Set<LibraryVariableSet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			LibraryVariableSet modifiedRecord = await context.Set<LibraryVariableSet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>357a96fcd7ffc31b817d81c7ba4fd284</Hash>
</Codenesium>*/