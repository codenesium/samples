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
	public partial class DeploymentProcessRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DeploymentProcessRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DeploymentProcessRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "DeploymentProcess")]
	[Trait("Area", "Repositories")]
	public partial class DeploymentProcessRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);

			DeploymentProcess entity = new DeploymentProcess();
			context.Set<DeploymentProcess>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);

			DeploymentProcess entity = new DeploymentProcess();
			context.Set<DeploymentProcess>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);

			var entity = new DeploymentProcess();
			await repository.Create(entity);

			var record = await context.Set<DeploymentProcess>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);
			DeploymentProcess entity = new DeploymentProcess();
			context.Set<DeploymentProcess>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<DeploymentProcess>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);
			DeploymentProcess entity = new DeploymentProcess();
			context.Set<DeploymentProcess>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new DeploymentProcess());

			var modifiedRecord = context.Set<DeploymentProcess>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<DeploymentProcessRepository>> loggerMoc = DeploymentProcessRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeploymentProcessRepositoryMoc.GetContext();
			var repository = new DeploymentProcessRepository(loggerMoc.Object, context);
			DeploymentProcess entity = new DeploymentProcess();
			context.Set<DeploymentProcess>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			DeploymentProcess modifiedRecord = await context.Set<DeploymentProcess>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>2cc50c92046e13788a79450bcf52b35c</Hash>
</Codenesium>*/