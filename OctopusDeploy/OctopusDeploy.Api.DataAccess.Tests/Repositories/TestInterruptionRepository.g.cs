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
	public partial class InterruptionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<InterruptionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<InterruptionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Interruption")]
	[Trait("Area", "Repositories")]
	public partial class InterruptionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);

			Interruption entity = new Interruption();
			context.Set<Interruption>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);

			Interruption entity = new Interruption();
			context.Set<Interruption>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);

			var entity = new Interruption();
			await repository.Create(entity);

			var record = await context.Set<Interruption>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);
			Interruption entity = new Interruption();
			context.Set<Interruption>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Interruption>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);
			Interruption entity = new Interruption();
			context.Set<Interruption>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Interruption());

			var modifiedRecord = context.Set<Interruption>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<InterruptionRepository>> loggerMoc = InterruptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = InterruptionRepositoryMoc.GetContext();
			var repository = new InterruptionRepository(loggerMoc.Object, context);
			Interruption entity = new Interruption();
			context.Set<Interruption>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Interruption modifiedRecord = await context.Set<Interruption>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>1ac5d1800ced567810fe6ae97419ee88</Hash>
</Codenesium>*/