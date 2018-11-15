using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "Repositories")]
	public partial class PetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			Pet entity = new Pet();
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			Pet entity = new Pet();
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			var entity = new Pet();
			await repository.Create(entity);

			var record = await context.Set<Pet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Pet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Pet());

			var modifiedRecord = context.Set<Pet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);
			Pet entity = new Pet();
			context.Set<Pet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Pet modifiedRecord = await context.Set<Pet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PetRepository>> loggerMoc = PetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PetRepositoryMoc.GetContext();
			var repository = new PetRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>7f6b929da2a58e21d6a53718441fa6a4</Hash>
</Codenesium>*/