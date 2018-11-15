using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherSkillServerRequestModelValidatorTest
	{
		public ApiTeacherSkillServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillServerRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillServerRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillServerRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillServerRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>226d14083df2764cc52c07513e77c63d</Hash>
</Codenesium>*/