using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class VoteTypesRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VoteTypesRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VoteTypesRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "Repositories")]
	public partial class VoteTypesRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);

			VoteTypes entity = new VoteTypes();
			context.Set<VoteTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);

			VoteTypes entity = new VoteTypes();
			context.Set<VoteTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);

			var entity = new VoteTypes();
			await repository.Create(entity);

			var record = await context.Set<VoteTypes>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);
			VoteTypes entity = new VoteTypes();
			context.Set<VoteTypes>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<VoteTypes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);
			VoteTypes entity = new VoteTypes();
			context.Set<VoteTypes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VoteTypes());

			var modifiedRecord = context.Set<VoteTypes>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VoteTypesRepository>> loggerMoc = VoteTypesRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypesRepositoryMoc.GetContext();
			var repository = new VoteTypesRepository(loggerMoc.Object, context);
			VoteTypes entity = new VoteTypes();
			context.Set<VoteTypes>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			VoteTypes modifiedRecord = await context.Set<VoteTypes>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>caa2e8645264b9e8b7bd4fd8635d8651</Hash>
</Codenesium>*/