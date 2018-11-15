using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class VoteTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VoteTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VoteTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "Repositories")]
	public partial class VoteTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);

			VoteType entity = new VoteType();
			context.Set<VoteType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);

			VoteType entity = new VoteType();
			context.Set<VoteType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);

			var entity = new VoteType();
			await repository.Create(entity);

			var record = await context.Set<VoteType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);
			VoteType entity = new VoteType();
			context.Set<VoteType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<VoteType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);
			VoteType entity = new VoteType();
			context.Set<VoteType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VoteType());

			var modifiedRecord = context.Set<VoteType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);
			VoteType entity = new VoteType();
			context.Set<VoteType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			VoteType modifiedRecord = await context.Set<VoteType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VoteTypeRepository>> loggerMoc = VoteTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VoteTypeRepositoryMoc.GetContext();
			var repository = new VoteTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d4eb6c92bb68985e9918d632bfb767ae</Hash>
</Codenesium>*/