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
	public partial class EventTeacherRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventTeacherRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventTeacherRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Repositories")]
	public partial class EventTeacherRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			EventTeacher entity = new EventTeacher();
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			EventTeacher entity = new EventTeacher();
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);

			var entity = new EventTeacher();
			await repository.Create(entity);

			var record = await context.Set<EventTeacher>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<EventTeacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EventTeacher());

			var modifiedRecord = context.Set<EventTeacher>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EventTeacherRepository>> loggerMoc = EventTeacherRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventTeacherRepositoryMoc.GetContext();
			var repository = new EventTeacherRepository(loggerMoc.Object, context);
			EventTeacher entity = new EventTeacher();
			context.Set<EventTeacher>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			EventTeacher modifiedRecord = await context.Set<EventTeacher>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0c095b3fb37662424653124b628a4703</Hash>
</Codenesium>*/