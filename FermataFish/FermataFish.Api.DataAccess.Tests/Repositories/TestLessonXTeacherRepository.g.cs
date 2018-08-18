using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FermataFishNS.Api.DataAccess
{
	public partial class LessonXTeacherRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LessonXTeacherRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LessonXTeacherRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LessonXTeacher")]
	[Trait("Area", "Repositories")]
	public partial class LessonXTeacherRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);

			LessonXTeacher entity = new LessonXTeacher();
			context.Set<LessonXTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);

			LessonXTeacher entity = new LessonXTeacher();
			context.Set<LessonXTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);

			var entity = new LessonXTeacher();
			await repository.Create(entity);

			var record = await context.Set<LessonXTeacher>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);
			LessonXTeacher entity = new LessonXTeacher();
			context.Set<LessonXTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<LessonXTeacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);
			LessonXTeacher entity = new LessonXTeacher();
			context.Set<LessonXTeacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new LessonXTeacher());

			var modifiedRecord = context.Set<LessonXTeacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LessonXTeacherRepository>> loggerMoc = LessonXTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LessonXTeacherRepositoryMoc.GetContext();
			var repository = new LessonXTeacherRepository(loggerMoc.Object, context);
			LessonXTeacher entity = new LessonXTeacher();
			context.Set<LessonXTeacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			LessonXTeacher modifiedRecord = await context.Set<LessonXTeacher>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>3c315014eea399e0dac75d17f9d85877</Hash>
</Codenesium>*/