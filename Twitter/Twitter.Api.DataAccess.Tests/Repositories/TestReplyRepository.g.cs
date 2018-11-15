using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class ReplyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ReplyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ReplyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "Repositories")]
	public partial class ReplyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			Reply entity = new Reply();
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			Reply entity = new Reply();
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ReplyId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			var entity = new Reply();
			await repository.Create(entity);

			var record = await context.Set<Reply>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ReplyId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Reply>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Reply());

			var modifiedRecord = context.Set<Reply>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ReplyId);

			Reply modifiedRecord = await context.Set<Reply>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ffce169448a8d67651969a4cc5e24b56</Hash>
</Codenesium>*/