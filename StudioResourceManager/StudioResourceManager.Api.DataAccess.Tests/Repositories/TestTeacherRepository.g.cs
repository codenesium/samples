using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class TeacherRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TeacherRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TeacherRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Teacher")]
	[Trait("Area", "Repositories")]
	public partial class TeacherRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);

			Teacher entity = new Teacher();
			context.Set<Teacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);

			Teacher entity = new Teacher();
			context.Set<Teacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);

			var entity = new Teacher();
			await repository.Create(entity);

			var record = await context.Set<Teacher>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);
			Teacher entity = new Teacher();
			context.Set<Teacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Teacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);
			Teacher entity = new Teacher();
			context.Set<Teacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Teacher());

			var modifiedRecord = context.Set<Teacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TeacherRepository>> loggerMoc = TeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherRepositoryMoc.GetContext();
			var repository = new TeacherRepository(loggerMoc.Object, context);
			Teacher entity = new Teacher();
			context.Set<Teacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Teacher modifiedRecord = await context.Set<Teacher>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>29e6fef88025b26a10c9a791289dc609</Hash>
</Codenesium>*/