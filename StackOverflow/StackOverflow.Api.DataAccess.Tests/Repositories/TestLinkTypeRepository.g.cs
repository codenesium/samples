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
	public partial class LinkTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LinkTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "Repositories")]
	public partial class LinkTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			LinkType entity = new LinkType();
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			LinkType entity = new LinkType();
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			var entity = new LinkType();
			await repository.Create(entity);

			var record = await context.Set<LinkType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<LinkType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new LinkType());

			var modifiedRecord = context.Set<LinkType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			LinkType modifiedRecord = await context.Set<LinkType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>dc54b21a67a82ed54353164de04ef567</Hash>
</Codenesium>*/