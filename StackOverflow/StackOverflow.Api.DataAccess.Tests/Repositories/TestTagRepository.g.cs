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
	public partial class TagRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TagRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TagRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "Repositories")]
	public partial class TagRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			Tag entity = new Tag();
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			Tag entity = new Tag();
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			var entity = new Tag();
			await repository.Create(entity);

			var record = await context.Set<Tag>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Tag>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Tag());

			var modifiedRecord = context.Set<Tag>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);
			Tag entity = new Tag();
			context.Set<Tag>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Tag modifiedRecord = await context.Set<Tag>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<TagRepository>> loggerMoc = TagRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagRepositoryMoc.GetContext();
			var repository = new TagRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>78213a89e872a3dce1104c0200c5af0c</Hash>
</Codenesium>*/