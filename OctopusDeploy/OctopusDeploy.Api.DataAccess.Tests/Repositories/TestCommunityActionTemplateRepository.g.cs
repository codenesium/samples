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
	public partial class CommunityActionTemplateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CommunityActionTemplateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CommunityActionTemplateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CommunityActionTemplate")]
	[Trait("Area", "Repositories")]
	public partial class CommunityActionTemplateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);

			CommunityActionTemplate entity = new CommunityActionTemplate();
			context.Set<CommunityActionTemplate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);

			CommunityActionTemplate entity = new CommunityActionTemplate();
			context.Set<CommunityActionTemplate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);

			var entity = new CommunityActionTemplate();
			await repository.Create(entity);

			var record = await context.Set<CommunityActionTemplate>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);
			CommunityActionTemplate entity = new CommunityActionTemplate();
			context.Set<CommunityActionTemplate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<CommunityActionTemplate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);
			CommunityActionTemplate entity = new CommunityActionTemplate();
			context.Set<CommunityActionTemplate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CommunityActionTemplate());

			var modifiedRecord = context.Set<CommunityActionTemplate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CommunityActionTemplateRepository>> loggerMoc = CommunityActionTemplateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CommunityActionTemplateRepositoryMoc.GetContext();
			var repository = new CommunityActionTemplateRepository(loggerMoc.Object, context);
			CommunityActionTemplate entity = new CommunityActionTemplate();
			context.Set<CommunityActionTemplate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			CommunityActionTemplate modifiedRecord = await context.Set<CommunityActionTemplate>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>b40bee74939076caf88b937c301f1aac</Hash>
</Codenesium>*/