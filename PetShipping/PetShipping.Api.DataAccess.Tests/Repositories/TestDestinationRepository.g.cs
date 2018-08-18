using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class DestinationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DestinationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DestinationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "Repositories")]
	public partial class DestinationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			Destination entity = new Destination();
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			Destination entity = new Destination();
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);

			var entity = new Destination();
			await repository.Create(entity);

			var record = await context.Set<Destination>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Destination>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Destination());

			var modifiedRecord = context.Set<Destination>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<DestinationRepository>> loggerMoc = DestinationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DestinationRepositoryMoc.GetContext();
			var repository = new DestinationRepository(loggerMoc.Object, context);
			Destination entity = new Destination();
			context.Set<Destination>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Destination modifiedRecord = await context.Set<Destination>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>9bc26d61d2962a9a8b509cf2c10e74a3</Hash>
</Codenesium>*/