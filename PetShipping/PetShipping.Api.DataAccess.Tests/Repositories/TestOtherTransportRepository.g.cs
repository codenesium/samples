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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<OtherTransportRepository>> loggerMoc = OtherTransportRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OtherTransportRepositoryMoc.GetContext();
			var repository = new OtherTransportRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0471c7935f4eb42d02b4bf908c43d259</Hash>
</Codenesium>*/