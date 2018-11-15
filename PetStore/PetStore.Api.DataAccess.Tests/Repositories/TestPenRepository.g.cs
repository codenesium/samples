using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.DataAccess
{
	public partial class PenRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PenRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PenRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "Repositories")]
	public partial class PenRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);

			Pen entity = new Pen();
			context.Set<Pen>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);

			Pen entity = new Pen();
			context.Set<Pen>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);

			var entity = new Pen();
			await repository.Create(entity);

			var record = await context.Set<Pen>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);
			Pen entity = new Pen();
			context.Set<Pen>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Pen>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);
			Pen entity = new Pen();
			context.Set<Pen>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Pen());

			var modifiedRecord = context.Set<Pen>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);
			Pen entity = new Pen();
			context.Set<Pen>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Pen modifiedRecord = await context.Set<Pen>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PenRepository>> loggerMoc = PenRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PenRepositoryMoc.GetContext();
			var repository = new PenRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e2270422767bac09b10622bddfbe889b</Hash>
</Codenesium>*/