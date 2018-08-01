using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetStoreNS.Api.DataAccess
{
	public partial class BreedRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<BreedRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BreedRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "Repositories")]
	public partial class BreedRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			Breed entity = new Breed();
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			Breed entity = new Breed();
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);

			var entity = new Breed();
			await repository.Create(entity);

			var record = await context.Set<Breed>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Breed>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Breed());

			var modifiedRecord = context.Set<Breed>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<BreedRepository>> loggerMoc = BreedRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BreedRepositoryMoc.GetContext();
			var repository = new BreedRepository(loggerMoc.Object, context);
			Breed entity = new Breed();
			context.Set<Breed>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Breed modifiedRecord = await context.Set<Breed>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0a2e34301ae6080fb3de104273c4af5a</Hash>
</Codenesium>*/