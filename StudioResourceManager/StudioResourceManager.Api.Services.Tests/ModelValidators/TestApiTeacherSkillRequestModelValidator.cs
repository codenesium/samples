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
	public partial class ApiTeacherSkillRequestModelValidatorTest
	{
		public ApiTeacherSkillRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITeacherSkillRepository> teacherSkillRepository = new Mock<ITeacherSkillRepository>();
			teacherSkillRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));

			var validator = new ApiTeacherSkillRequestModelValidator(teacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>ec2381c4694eeb05afce64bfd396411b</Hash>
</Codenesium>*/