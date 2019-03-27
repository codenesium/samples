using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherTeacherSkillServerRequestModelValidatorTest
	{
		public ApiTeacherTeacherSkillServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillServerRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillServerRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillServerRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillServerRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>a24b2c033da3143ca11e377336eb3d27</Hash>
</Codenesium>*/