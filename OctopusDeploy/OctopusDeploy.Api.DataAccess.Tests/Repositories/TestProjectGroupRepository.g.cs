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
	public partial class ProjectGroupRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProjectGroupRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProjectGroupRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProjectGroup")]
	[Trait("Area", "Repositories")]
	public partial class ProjectGroupRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);

			ProjectGroup entity = new ProjectGroup();
			context.Set<ProjectGroup>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);

			ProjectGroup entity = new ProjectGroup();
			context.Set<ProjectGroup>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);

			var entity = new ProjectGroup();
			await repository.Create(entity);

			var record = await context.Set<ProjectGroup>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);
			ProjectGroup entity = new ProjectGroup();
			context.Set<ProjectGroup>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProjectGroup>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);
			ProjectGroup entity = new ProjectGroup();
			context.Set<ProjectGroup>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProjectGroup());

			var modifiedRecord = context.Set<ProjectGroup>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProjectGroupRepository>> loggerMoc = ProjectGroupRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProjectGroupRepositoryMoc.GetContext();
			var repository = new ProjectGroupRepository(loggerMoc.Object, context);
			ProjectGroup entity = new ProjectGroup();
			context.Set<ProjectGroup>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ProjectGroup modifiedRecord = await context.Set<ProjectGroup>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>7301ef98b08605261e3ca34d32722222</Hash>
</Codenesium>*/