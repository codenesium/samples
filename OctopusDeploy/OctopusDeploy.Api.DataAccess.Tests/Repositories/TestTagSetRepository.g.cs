using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class TagSetRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TagSetRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TagSetRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TagSet")]
	[Trait("Area", "Repositories")]
	public partial class TagSetRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);

			TagSet entity = new TagSet();
			context.Set<TagSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);

			TagSet entity = new TagSet();
			context.Set<TagSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);

			var entity = new TagSet();
			await repository.Create(entity);

			var record = await context.Set<TagSet>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);
			TagSet entity = new TagSet();
			context.Set<TagSet>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TagSet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);
			TagSet entity = new TagSet();
			context.Set<TagSet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TagSet());

			var modifiedRecord = context.Set<TagSet>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TagSetRepository>> loggerMoc = TagSetRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TagSetRepositoryMoc.GetContext();
			var repository = new TagSetRepository(loggerMoc.Object, context);
			TagSet entity = new TagSet();
			context.Set<TagSet>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TagSet modifiedRecord = await context.Set<TagSet>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>9fe516c02dfe4850bc1c8ab0ecbf7989</Hash>
</Codenesium>*/