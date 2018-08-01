using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FermataFishNS.Api.DataAccess
{
	public partial class FamilyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<FamilyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FamilyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "Repositories")]
	public partial class FamilyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			Family entity = new Family();
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			Family entity = new Family();
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);

			var entity = new Family();
			await repository.Create(entity);

			var record = await context.Set<Family>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Family>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Family());

			var modifiedRecord = context.Set<Family>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<FamilyRepository>> loggerMoc = FamilyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FamilyRepositoryMoc.GetContext();
			var repository = new FamilyRepository(loggerMoc.Object, context);
			Family entity = new Family();
			context.Set<Family>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Family modifiedRecord = await context.Set<Family>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>d8f54e104ac0fb1f3e63c95396a9f22a</Hash>
</Codenesium>*/