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
	[Trait("Table", "Rate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiRateRequestModelValidatorTest
	{
		public ApiRateRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetTeacherSkill(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>e78cac93e66ef2d206d16ab92cbbfb17</Hash>
</Codenesium>*/