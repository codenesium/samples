using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
	public partial class SelfReferenceRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SelfReferenceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SelfReferenceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Repositories")]
	public partial class SelfReferenceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);

			SelfReference entity = new SelfReference();
			context.Set<SelfReference>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);

			SelfReference entity = new SelfReference();
			context.Set<SelfReference>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);

			var entity = new SelfReference();
			await repository.Create(entity);

			var record = await context.Set<SelfReference>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);
			SelfReference entity = new SelfReference();
			context.Set<SelfReference>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SelfReference>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);
			SelfReference entity = new SelfReference();
			context.Set<SelfReference>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SelfReference());

			var modifiedRecord = context.Set<SelfReference>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);
			SelfReference entity = new SelfReference();
			context.Set<SelfReference>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SelfReference modifiedRecord = await context.Set<SelfReference>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f2bdc37c5eab6a4d8c9f846207e23094</Hash>
</Codenesium>*/