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
	public partial class OctopusServerNodeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<OctopusServerNodeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<OctopusServerNodeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "OctopusServerNode")]
	[Trait("Area", "Repositories")]
	public partial class OctopusServerNodeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);

			OctopusServerNode entity = new OctopusServerNode();
			context.Set<OctopusServerNode>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);

			OctopusServerNode entity = new OctopusServerNode();
			context.Set<OctopusServerNode>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);

			var entity = new OctopusServerNode();
			await repository.Create(entity);

			var record = await context.Set<OctopusServerNode>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);
			OctopusServerNode entity = new OctopusServerNode();
			context.Set<OctopusServerNode>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<OctopusServerNode>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);
			OctopusServerNode entity = new OctopusServerNode();
			context.Set<OctopusServerNode>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new OctopusServerNode());

			var modifiedRecord = context.Set<OctopusServerNode>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<OctopusServerNodeRepository>> loggerMoc = OctopusServerNodeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OctopusServerNodeRepositoryMoc.GetContext();
			var repository = new OctopusServerNodeRepository(loggerMoc.Object, context);
			OctopusServerNode entity = new OctopusServerNode();
			context.Set<OctopusServerNode>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			OctopusServerNode modifiedRecord = await context.Set<OctopusServerNode>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>8ff9ab849611a72d0365f8097028cabc</Hash>
</Codenesium>*/