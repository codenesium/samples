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
	public partial class ActionTemplateVersionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ActionTemplateVersionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ActionTemplateVersionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ActionTemplateVersion")]
	[Trait("Area", "Repositories")]
	public partial class ActionTemplateVersionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);

			ActionTemplateVersion entity = new ActionTemplateVersion();
			context.Set<ActionTemplateVersion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);

			ActionTemplateVersion entity = new ActionTemplateVersion();
			context.Set<ActionTemplateVersion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);

			var entity = new ActionTemplateVersion();
			await repository.Create(entity);

			var record = await context.Set<ActionTemplateVersion>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);
			ActionTemplateVersion entity = new ActionTemplateVersion();
			context.Set<ActionTemplateVersion>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ActionTemplateVersion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);
			ActionTemplateVersion entity = new ActionTemplateVersion();
			context.Set<ActionTemplateVersion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ActionTemplateVersion());

			var modifiedRecord = context.Set<ActionTemplateVersion>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ActionTemplateVersionRepository>> loggerMoc = ActionTemplateVersionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ActionTemplateVersionRepositoryMoc.GetContext();
			var repository = new ActionTemplateVersionRepository(loggerMoc.Object, context);
			ActionTemplateVersion entity = new ActionTemplateVersion();
			context.Set<ActionTemplateVersion>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ActionTemplateVersion modifiedRecord = await context.Set<ActionTemplateVersion>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>6fe8d05318fad2976d42391211b5f028</Hash>
</Codenesium>*/