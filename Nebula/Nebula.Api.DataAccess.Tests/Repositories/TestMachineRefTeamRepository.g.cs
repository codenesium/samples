using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class MachineRefTeamRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<MachineRefTeamRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<MachineRefTeamRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "Repositories")]
	public partial class MachineRefTeamRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);

			MachineRefTeam entity = new MachineRefTeam();
			context.Set<MachineRefTeam>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);

			MachineRefTeam entity = new MachineRefTeam();
			context.Set<MachineRefTeam>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);

			var entity = new MachineRefTeam();
			await repository.Create(entity);

			var record = await context.Set<MachineRefTeam>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);
			MachineRefTeam entity = new MachineRefTeam();
			context.Set<MachineRefTeam>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<MachineRefTeam>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);
			MachineRefTeam entity = new MachineRefTeam();
			context.Set<MachineRefTeam>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new MachineRefTeam());

			var modifiedRecord = context.Set<MachineRefTeam>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<MachineRefTeamRepository>> loggerMoc = MachineRefTeamRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRefTeamRepositoryMoc.GetContext();
			var repository = new MachineRefTeamRepository(loggerMoc.Object, context);
			MachineRefTeam entity = new MachineRefTeam();
			context.Set<MachineRefTeam>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			MachineRefTeam modifiedRecord = await context.Set<MachineRefTeam>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>e53d34a1d5409066cbb903b878bc3760</Hash>
</Codenesium>*/