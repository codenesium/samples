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
	public partial class CompositePrimaryKeyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CompositePrimaryKeyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CompositePrimaryKeyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Repositories")]
	public partial class CompositePrimaryKeyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			CompositePrimaryKey entity = new CompositePrimaryKey();
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			CompositePrimaryKey entity = new CompositePrimaryKey();
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);

			var entity = new CompositePrimaryKey();
			await repository.Create(entity);

			var record = await context.Set<CompositePrimaryKey>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<CompositePrimaryKey>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CompositePrimaryKey());

			var modifiedRecord = context.Set<CompositePrimaryKey>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CompositePrimaryKeyRepository>> loggerMoc = CompositePrimaryKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CompositePrimaryKeyRepositoryMoc.GetContext();
			var repository = new CompositePrimaryKeyRepository(loggerMoc.Object, context);
			CompositePrimaryKey entity = new CompositePrimaryKey();
			context.Set<CompositePrimaryKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			CompositePrimaryKey modifiedRecord = await context.Set<CompositePrimaryKey>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f3d813234df18b7149fa286e592e5bda</Hash>
</Codenesium>*/