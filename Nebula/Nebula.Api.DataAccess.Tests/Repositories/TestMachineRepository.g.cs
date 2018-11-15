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
	public partial class MachineRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<MachineRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<MachineRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Repositories")]
	public partial class MachineRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);

			Machine entity = new Machine();
			context.Set<Machine>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);

			Machine entity = new Machine();
			context.Set<Machine>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);

			var entity = new Machine();
			await repository.Create(entity);

			var record = await context.Set<Machine>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);
			Machine entity = new Machine();
			context.Set<Machine>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Machine>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);
			Machine entity = new Machine();
			context.Set<Machine>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Machine());

			var modifiedRecord = context.Set<Machine>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);
			Machine entity = new Machine();
			context.Set<Machine>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Machine modifiedRecord = await context.Set<Machine>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<MachineRepository>> loggerMoc = MachineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = MachineRepositoryMoc.GetContext();
			var repository = new MachineRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6dfc81d558fddf557bc226a438661d0a</Hash>
</Codenesium>*/