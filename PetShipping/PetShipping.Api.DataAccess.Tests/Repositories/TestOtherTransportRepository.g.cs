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
	public partial class OtherTransportRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<OtherTransportRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<OtherTransportRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Repositories")]
	public partial class OtherTransportRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			OtherTransport entity = new OtherTransport();
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			OtherTransport entity = new OtherTransport();
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			var entity = new OtherTransport();
			await repository.Create(entity);

			var record = await context.Set<OtherTransport>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<OtherTransport>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new OtherTransport());

			var modifiedRecord = context.Set<OtherTransport>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);
			OtherTransport entity = new OtherTransport();
			context.Set<OtherTransport>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			OtherTransport modifiedRecord = await context.Set<OtherTransport>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>8484ff0f662540a1d20a4a50254c7bfa</Hash>
</Codenesium>*/