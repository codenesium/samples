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
	}
}

/*<Codenesium>
    <Hash>959162e4b81e29ce26d658ef5492ccba</Hash>
</Codenesium>*/