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

		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<ITeacherTeacherSkillRepository> teacherTeacherSkillRepository = new Mock<ITeacherTeacherSkillRepository>();
			teacherTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherTeacherSkillRequestModelValidator(teacherTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>82b206e7153915a382e35b7e766c6c03</Hash>
</Codenesium>*/