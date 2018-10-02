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

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);

			var entity = new VProductAndDescription();
			await repository.Create(entity);

			var record = await context.Set<VProductAndDescription>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);
			VProductAndDescription entity = new VProductAndDescription();
			context.Set<VProductAndDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CultureID);

			await repository.Update(record);

			var modifiedRecord = context.Set<VProductAndDescription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);
			VProductAndDescription entity = new VProductAndDescription();
			context.Set<VProductAndDescription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VProductAndDescription());

			var modifiedRecord = context.Set<VProductAndDescription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VProductAndDescriptionRepository>> loggerMoc = VProductAndDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VProductAndDescriptionRepositoryMoc.GetContext();
			var repository = new VProductAndDescriptionRepository(loggerMoc.Object, context);
			VProductAndDescription entity = new VProductAndDescription();
			context.Set<VProductAndDescription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CultureID);

			VProductAndDescription modifiedRecord = await context.Set<VProductAndDescription>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>31507cb5af64dc636c625a4ccee2abe5</Hash>
</Codenesium>*/