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
	public partial class TeacherTeacherSkillRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TeacherTeacherSkillRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TeacherTeacherSkillRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Repositories")]
	public partial class TeacherTeacherSkillRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);

			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			context.Set<TeacherTeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);

			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			context.Set<TeacherTeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);

			var entity = new TeacherTeacherSkill();
			await repository.Create(entity);

			var record = await context.Set<TeacherTeacherSkill>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			context.Set<TeacherTeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TeacherTeacherSkill>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			context.Set<TeacherTeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TeacherTeacherSkill());

			var modifiedRecord = context.Set<TeacherTeacherSkill>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TeacherTeacherSkillRepository>> loggerMoc = TeacherTeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherTeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherTeacherSkillRepository(loggerMoc.Object, context);
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			context.Set<TeacherTeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TeacherTeacherSkill modifiedRecord = await context.Set<TeacherTeacherSkill>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>27b7438972e3b305b99d7973e16ca4ca</Hash>
</Codenesium>*/