using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ShiftRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ShiftRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ShiftRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "Repositories")]
	public partial class ShiftRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			Shift entity = new Shift();
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			Shift entity = new Shift();
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShiftID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			var entity = new Shift();
			await repository.Create(entity);

			var record = await context.Set<Shift>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShiftID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Shift>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Shift());

			var modifiedRecord = context.Set<Shift>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);
			Shift entity = new Shift();
			context.Set<Shift>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ShiftID);

			Shift modifiedRecord = await context.Set<Shift>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ShiftRepository>> loggerMoc = ShiftRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShiftRepositoryMoc.GetContext();
			var repository = new ShiftRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>3f9e07681727893e2efc6022f493f49b</Hash>
</Codenesium>*/