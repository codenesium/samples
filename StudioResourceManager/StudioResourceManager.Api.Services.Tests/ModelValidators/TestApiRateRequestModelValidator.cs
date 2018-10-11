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
	public partial class ApiRateRequestModelValidatorTest
	{
		public ApiRateRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Teacher
		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		// table.Columns[i].GetReferenceTable().AppTableName= TeacherSkill
		[Fact]
		public async void TeacherSkillId_Create_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Create_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateCreateAsync(new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Valid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(new TeacherSkill()));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}

		[Fact]
		public async void TeacherSkillId_Update_Invalid_Reference()
		{
			Mock<IRateRepository> rateRepository = new Mock<IRateRepository>();
			rateRepository.Setup(x => x.TeacherSkillByTeacherSkillId(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));

			var validator = new ApiRateRequestModelValidator(rateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherSkillId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>934e54ac54d346d37d9e4efc0e792e0e</Hash>
</Codenesium>*/