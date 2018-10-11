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
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherTeacherSkillRequestModelValidatorTest
	{
		public ApiTeacherTeacherSkillRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= TeacherSkill
		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c3bf97b50bcd2e7e88c75c90221931c2</Hash>
</Codenesium>*/