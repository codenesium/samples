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
	public partial class EventStudentRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<EventStudentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<EventStudentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Repositories")]
	public partial class EventStudentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);

			EventStudent entity = new EventStudent();
			context.Set<EventStudent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);

			EventStudent entity = new EventStudent();
			context.Set<EventStudent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);

			var entity = new EventStudent();
			await repository.Create(entity);

			var record = await context.Set<EventStudent>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);
			EventStudent entity = new EventStudent();
			context.Set<EventStudent>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<EventStudent>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);
			EventStudent entity = new EventStudent();
			context.Set<EventStudent>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new EventStudent());

			var modifiedRecord = context.Set<EventStudent>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<EventStudentRepository>> loggerMoc = EventStudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = EventStudentRepositoryMoc.GetContext();
			var repository = new EventStudentRepository(loggerMoc.Object, context);
			EventStudent entity = new EventStudent();
			context.Set<EventStudent>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			EventStudent modifiedRecord = await context.Set<EventStudent>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>1d7c7010ac7d4f9751c1b4559ff62d91</Hash>
</Codenesium>*/