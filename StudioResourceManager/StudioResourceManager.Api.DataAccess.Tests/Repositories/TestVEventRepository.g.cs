using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class VEventRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VEventRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VEventRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VEvent")]
	[Trait("Area", "Repositories")]
	public partial class VEventRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);

			VEvent entity = new VEvent();
			context.Set<VEvent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);

			VEvent entity = new VEvent();
			context.Set<VEvent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);

			var entity = new VEvent();
			await repository.Create(entity);

			var record = await context.Set<VEvent>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);
			VEvent entity = new VEvent();
			context.Set<VEvent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<VEvent>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);
			VEvent entity = new VEvent();
			context.Set<VEvent>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VEvent());

			var modifiedRecord = context.Set<VEvent>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VEventRepository>> loggerMoc = VEventRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VEventRepositoryMoc.GetContext();
			var repository = new VEventRepository(loggerMoc.Object, context);
			VEvent entity = new VEvent();
			context.Set<VEvent>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			VEvent modifiedRecord = await context.Set<VEvent>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>1e9564ba9d77e17962b80b6124740b44</Hash>
</Codenesium>*/