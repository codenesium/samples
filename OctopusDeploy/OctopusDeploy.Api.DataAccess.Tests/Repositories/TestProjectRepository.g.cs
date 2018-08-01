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
	public partial class ProjectRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProjectRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProjectRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Project")]
	[Trait("Area", "Repositories")]
	public partial class ProjectRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);

			Project entity = new Project();
			context.Set<Project>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);

			Project entity = new Project();
			context.Set<Project>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);

			var entity = new Project();
			await repository.Create(entity);

			var record = await context.Set<Project>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);
			Project entity = new Project();
			context.Set<Project>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Project>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);
			Project entity = new Project();
			context.Set<Project>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Project());

			var modifiedRecord = context.Set<Project>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProjectRepository>> loggerMoc = ProjectRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectRepositoryMoc.GetContext();
			var repository = new ProjectRepository(loggerMoc.Object, context);
			Project entity = new Project();
			context.Set<Project>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Project modifiedRecord = await context.Set<Project>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>87077ea6eaeb6d232e44ae1e2205d598</Hash>
</Codenesium>*/