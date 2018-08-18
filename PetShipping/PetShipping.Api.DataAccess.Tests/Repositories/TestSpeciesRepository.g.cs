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
	public partial class SpeciesRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SpeciesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpeciesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "Repositories")]
	public partial class SpeciesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);

			Species entity = new Species();
			context.Set<Species>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);

			Species entity = new Species();
			context.Set<Species>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);

			var entity = new Species();
			await repository.Create(entity);

			var record = await context.Set<Species>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);
			Species entity = new Species();
			context.Set<Species>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Species>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);
			Species entity = new Species();
			context.Set<Species>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Species());

			var modifiedRecord = context.Set<Species>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SpeciesRepository>> loggerMoc = SpeciesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpeciesRepositoryMoc.GetContext();
			var repository = new SpeciesRepository(loggerMoc.Object, context);
			Species entity = new Species();
			context.Set<Species>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Species modifiedRecord = await context.Set<Species>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>9f1e6d069d635c672c198dcae2c25bfc</Hash>
</Codenesium>*/