using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.DataAccess
{
	public partial class FileRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<FileRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<FileRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "Repositories")]
	public partial class FileRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			File entity = new File();
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			File entity = new File();
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			var entity = new File();
			await repository.Create(entity);

			var record = await context.Set<File>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<File>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new File());

			var modifiedRecord = context.Set<File>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);
			File entity = new File();
			context.Set<File>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			File modifiedRecord = await context.Set<File>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<FileRepository>> loggerMoc = FileRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = FileRepositoryMoc.GetContext();
			var repository = new FileRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a7395ddaff1a41ce67d0b39f264740b2</Hash>
</Codenesium>*/