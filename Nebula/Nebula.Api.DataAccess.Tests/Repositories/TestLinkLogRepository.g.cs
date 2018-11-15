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
	public partial class LinkLogRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LinkLogRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkLogRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "Repositories")]
	public partial class LinkLogRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);

			LinkLog entity = new LinkLog();
			context.Set<LinkLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);

			LinkLog entity = new LinkLog();
			context.Set<LinkLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);

			var entity = new LinkLog();
			await repository.Create(entity);

			var record = await context.Set<LinkLog>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);
			LinkLog entity = new LinkLog();
			context.Set<LinkLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<LinkLog>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);
			LinkLog entity = new LinkLog();
			context.Set<LinkLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new LinkLog());

			var modifiedRecord = context.Set<LinkLog>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);
			LinkLog entity = new LinkLog();
			context.Set<LinkLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			LinkLog modifiedRecord = await context.Set<LinkLog>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkLogRepository>> loggerMoc = LinkLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkLogRepositoryMoc.GetContext();
			var repository = new LinkLogRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d96156c58177901b81ac66963ff48b3c</Hash>
</Codenesium>*/