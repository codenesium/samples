using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class TeamRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TeamRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TeamRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "Repositories")]
	public partial class TeamRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			Team entity = new Team();
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			Team entity = new Team();
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			var entity = new Team();
			await repository.Create(entity);

			var record = await context.Set<Team>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Team>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Team());

			var modifiedRecord = context.Set<Team>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);
			Team entity = new Team();
			context.Set<Team>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Team modifiedRecord = await context.Set<Team>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TeamRepository>> loggerMoc = TeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeamRepositoryMoc.GetContext();
			var repository = new TeamRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ee73ab2e58bca5b4369851314c2d06b3</Hash>
</Codenesium>*/