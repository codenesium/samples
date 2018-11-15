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
	public partial class DeviceRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DeviceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DeviceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "Repositories")]
	public partial class DeviceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			Device entity = new Device();
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			Device entity = new Device();
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			var entity = new Device();
			await repository.Create(entity);

			var record = await context.Set<Device>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Device>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Device());

			var modifiedRecord = context.Set<Device>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);
			Device entity = new Device();
			context.Set<Device>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Device modifiedRecord = await context.Set<Device>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<DeviceRepository>> loggerMoc = DeviceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DeviceRepositoryMoc.GetContext();
			var repository = new DeviceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>555cb36036a317cae066834c0ea760ff</Hash>
</Codenesium>*/