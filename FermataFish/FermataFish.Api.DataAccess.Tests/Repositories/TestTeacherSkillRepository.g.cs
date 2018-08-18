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
	public partial class TeacherSkillRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TeacherSkillRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TeacherSkillRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "Repositories")]
	public partial class TeacherSkillRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);

			TeacherSkill entity = new TeacherSkill();
			context.Set<TeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);

			TeacherSkill entity = new TeacherSkill();
			context.Set<TeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);

			var entity = new TeacherSkill();
			await repository.Create(entity);

			var record = await context.Set<TeacherSkill>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);
			TeacherSkill entity = new TeacherSkill();
			context.Set<TeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<TeacherSkill>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);
			TeacherSkill entity = new TeacherSkill();
			context.Set<TeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new TeacherSkill());

			var modifiedRecord = context.Set<TeacherSkill>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TeacherSkillRepository>> loggerMoc = TeacherSkillRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TeacherSkillRepositoryMoc.GetContext();
			var repository = new TeacherSkillRepository(loggerMoc.Object, context);
			TeacherSkill entity = new TeacherSkill();
			context.Set<TeacherSkill>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			TeacherSkill modifiedRecord = await context.Set<TeacherSkill>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>be47b6fe8c436b7cd5165751bc321794</Hash>
</Codenesium>*/