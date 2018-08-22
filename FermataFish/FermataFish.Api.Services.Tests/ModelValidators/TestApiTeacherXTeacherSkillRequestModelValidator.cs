using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherXTeacherSkill")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherXTeacherSkillRequestModelValidatorTest
	{
		public ApiTeacherXTeacherSkillRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<ITeacherXTeacherSkillRepository> teacherXTeacherSkillRepository = new Mock<ITeacherXTeacherSkillRepository>();
			teacherXTeacherSkillRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiTeacherXTeacherSkillRequestModelValidator(teacherXTeacherSkillRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherXTeacherSkillRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>b4c342a8a4a2dfbdeac4be4f659fd7d6</Hash>
</Codenesium>*/