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
	public partial class AirTransportRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<AirTransportRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AirTransportRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Repositories")]
	public partial class AirTransportRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			AirTransport entity = new AirTransport();
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			AirTransport entity = new AirTransport();
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AirlineId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			var entity = new AirTransport();
			await repository.Create(entity);

			var record = await context.Set<AirTransport>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AirlineId);

			await repository.Update(record);

			var modifiedRecord = context.Set<AirTransport>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new AirTransport());

			var modifiedRecord = context.Set<AirTransport>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);
			AirTransport entity = new AirTransport();
			context.Set<AirTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.AirlineId);

			AirTransport modifiedRecord = await context.Set<AirTransport>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>86b397a0fc61e38096f529c3ab17975e</Hash>
</Codenesium>*/