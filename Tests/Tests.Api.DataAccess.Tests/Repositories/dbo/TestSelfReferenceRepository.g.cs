using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SelfReferenceRepository>> loggerMoc = SelfReferenceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SelfReferenceRepositoryMoc.GetContext();
			var repository = new SelfReferenceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0e0ab7a5916de094e0a0862adfc3d036</Hash>
</Codenesium>*/