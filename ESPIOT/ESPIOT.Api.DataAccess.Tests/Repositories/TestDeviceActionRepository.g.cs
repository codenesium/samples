using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.DataAccess
{
	public partial class DeviceActionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DeviceActionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DeviceActionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Repositories")]
	public partial class DeviceActionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);

			DeviceAction entity = new DeviceAction();
			context.Set<DeviceAction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);

			DeviceAction entity = new DeviceAction();
			context.Set<DeviceAction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);

			var entity = new DeviceAction();
			await repository.Create(entity);

			var record = await context.Set<DeviceAction>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);
			DeviceAction entity = new DeviceAction();
			context.Set<DeviceAction>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<DeviceAction>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);
			DeviceAction entity = new DeviceAction();
			context.Set<DeviceAction>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new DeviceAction());

			var modifiedRecord = context.Set<DeviceAction>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);
			DeviceAction entity = new DeviceAction();
			context.Set<DeviceAction>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			DeviceAction modifiedRecord = await context.Set<DeviceAction>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DeviceActionRepository>> loggerMoc = DeviceActionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceActionRepositoryMoc.GetContext();
			var repository = new DeviceActionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2bae701ec216ce96ffcaafd82eca6dd0</Hash>
</Codenesium>*/