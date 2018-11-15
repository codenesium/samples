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
	public partial class RowVersionCheckRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<RowVersionCheckRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RowVersionCheckRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Repositories")]
	public partial class RowVersionCheckRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			RowVersionCheck entity = new RowVersionCheck();
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			RowVersionCheck entity = new RowVersionCheck();
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			var entity = new RowVersionCheck();
			await repository.Create(entity);

			var record = await context.Set<RowVersionCheck>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<RowVersionCheck>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new RowVersionCheck());

			var modifiedRecord = context.Set<RowVersionCheck>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);
			RowVersionCheck entity = new RowVersionCheck();
			context.Set<RowVersionCheck>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			RowVersionCheck modifiedRecord = await context.Set<RowVersionCheck>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<RowVersionCheckRepository>> loggerMoc = RowVersionCheckRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RowVersionCheckRepositoryMoc.GetContext();
			var repository = new RowVersionCheckRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6332fcc8d65c66d13f349fceefc148fa</Hash>
</Codenesium>*/