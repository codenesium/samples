using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AirTransportRepository>> loggerMoc = AirTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirTransportRepositoryMoc.GetContext();
			var repository = new AirTransportRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>623ffb50f16b7b1610d156b00b4855e9</Hash>
</Codenesium>*/