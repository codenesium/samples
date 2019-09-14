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
    <Hash>83aacd29773d425754ad318c5d76f863</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/