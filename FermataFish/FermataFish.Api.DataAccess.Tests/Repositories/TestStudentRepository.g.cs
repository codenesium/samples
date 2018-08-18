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
	public partial class StudentRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<StudentRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<StudentRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "Repositories")]
	public partial class StudentRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);

			Student entity = new Student();
			context.Set<Student>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);

			Student entity = new Student();
			context.Set<Student>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);

			var entity = new Student();
			await repository.Create(entity);

			var record = await context.Set<Student>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);
			Student entity = new Student();
			context.Set<Student>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Student>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);
			Student entity = new Student();
			context.Set<Student>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Student());

			var modifiedRecord = context.Set<Student>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<StudentRepository>> loggerMoc = StudentRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StudentRepositoryMoc.GetContext();
			var repository = new StudentRepository(loggerMoc.Object, context);
			Student entity = new Student();
			context.Set<Student>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Student modifiedRecord = await context.Set<Student>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f1ecfa88cbaf6fc3ccb7597d52e8a4af</Hash>
</Codenesium>*/