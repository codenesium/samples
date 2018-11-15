using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class SpaceRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SpaceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpaceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "Repositories")]
	public partial class SpaceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			Space entity = new Space();
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			Space entity = new Space();
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			var entity = new Space();
			await repository.Create(entity);

			var record = await context.Set<Space>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Space>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Space());

			var modifiedRecord = context.Set<Space>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);
			Space entity = new Space();
			context.Set<Space>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Space modifiedRecord = await context.Set<Space>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SpaceRepository>> loggerMoc = SpaceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpaceRepositoryMoc.GetContext();
			var repository = new SpaceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>11291452e1352f4885be182d67844cf0</Hash>
</Codenesium>*/