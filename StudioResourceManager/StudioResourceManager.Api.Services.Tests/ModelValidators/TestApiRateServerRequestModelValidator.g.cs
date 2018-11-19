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
	[Trait("Table", "Rate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiRateServerRequestModelValidatorTest
	{
		public ApiRateServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateServerRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>03515370b0b3e1a9c392849ad6d53e5d</Hash>
</Codenesium>*/