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
	public partial class LifecycleRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LifecycleRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LifecycleRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Lifecycle")]
	[Trait("Area", "Repositories")]
	public partial class LifecycleRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);

			Lifecycle entity = new Lifecycle();
			context.Set<Lifecycle>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);

			Lifecycle entity = new Lifecycle();
			context.Set<Lifecycle>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);

			var entity = new Lifecycle();
			await repository.Create(entity);

			var record = await context.Set<Lifecycle>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);
			Lifecycle entity = new Lifecycle();
			context.Set<Lifecycle>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Lifecycle>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);
			Lifecycle entity = new Lifecycle();
			context.Set<Lifecycle>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Lifecycle());

			var modifiedRecord = context.Set<Lifecycle>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LifecycleRepository>> loggerMoc = LifecycleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LifecycleRepositoryMoc.GetContext();
			var repository = new LifecycleRepository(loggerMoc.Object, context);
			Lifecycle entity = new Lifecycle();
			context.Set<Lifecycle>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Lifecycle modifiedRecord = await context.Set<Lifecycle>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f3a52dc8c715f477b106b04374dfdb85</Hash>
</Codenesium>*/