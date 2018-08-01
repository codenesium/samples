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
	public partial class ArtifactRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ArtifactRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ArtifactRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Artifact")]
	[Trait("Area", "Repositories")]
	public partial class ArtifactRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);

			Artifact entity = new Artifact();
			context.Set<Artifact>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);

			Artifact entity = new Artifact();
			context.Set<Artifact>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);

			var entity = new Artifact();
			await repository.Create(entity);

			var record = await context.Set<Artifact>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);
			Artifact entity = new Artifact();
			context.Set<Artifact>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Artifact>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);
			Artifact entity = new Artifact();
			context.Set<Artifact>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Artifact());

			var modifiedRecord = context.Set<Artifact>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ArtifactRepository>> loggerMoc = ArtifactRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ArtifactRepositoryMoc.GetContext();
			var repository = new ArtifactRepository(loggerMoc.Object, context);
			Artifact entity = new Artifact();
			context.Set<Artifact>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Artifact modifiedRecord = await context.Set<Artifact>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>e8e07e075937daec30eb66e9c844ce48</Hash>
</Codenesium>*/