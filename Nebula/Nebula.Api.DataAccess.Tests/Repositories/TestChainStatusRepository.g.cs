using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainStatusRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ChainStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ChainStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Repositories")]
	public partial class ChainStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			var entity = new ChainStatus();
			await repository.Create(entity);

			var record = await context.Set<ChainStatus>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ChainStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ChainStatus());

			var modifiedRecord = context.Set<ChainStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ChainStatus modifiedRecord = await context.Set<ChainStatus>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c8d356bb22c4c16b6040291e2ece226f</Hash>
</Codenesium>*/