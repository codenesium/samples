using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class VProductAndDescriptionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VProductAndDescriptionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VProductAndDescriptionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Repositories")]
	public partial class VProductAndDescriptionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);

			VProductAndDescription entity = new VProductAndDescription();
			context.Set<VProductAndDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);

			VProductAndDescription entity = new VProductAndDescription();
			context.Set<VProductAndDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			record.Should().NotBeNull();
		}
	}
}

/*<Codenesium>
    <Hash>cb7f373de583cca776a8a2fbbebe65f0</Hash>
</Codenesium>*/