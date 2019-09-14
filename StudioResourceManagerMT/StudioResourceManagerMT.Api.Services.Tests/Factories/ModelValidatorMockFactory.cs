using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAdminServerRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminServerRequestModelValidator>();

		public Mock<IApiEventServerRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventServerRequestModelValidator>();

		public Mock<IApiEventStatusServerRequestModelValidator> EventStatusModelValidatorMock { get; set; } = new Mock<IApiEventStatusServerRequestModelValidator>();

		public Mock<IApiEventStudentServerRequestModelValidator> EventStudentModelValidatorMock { get; set; } = new Mock<IApiEventStudentServerRequestModelValidator>();

		public Mock<IApiEventTeacherServerRequestModelValidator> EventTeacherModelValidatorMock { get; set; } = new Mock<IApiEventTeacherServerRequestModelValidator>();

		public Mock<IApiFamilyServerRequestModelValidator> FamilyModelValidatorMock { get; set; } = new Mock<IApiFamilyServerRequestModelValidator>();

		public Mock<IApiRateServerRequestModelValidator> RateModelValidatorMock { get; set; } = new Mock<IApiRateServerRequestModelValidator>();

		public Mock<IApiSpaceServerRequestModelValidator> SpaceModelValidatorMock { get; set; } = new Mock<IApiSpaceServerRequestModelValidator>();

		public Mock<IApiSpaceFeatureServerRequestModelValidator> SpaceFeatureModelValidatorMock { get; set; } = new Mock<IApiSpaceFeatureServerRequestModelValidator>();

		public Mock<IApiSpaceSpaceFeatureServerRequestModelValidator> SpaceSpaceFeatureModelValidatorMock { get; set; } = new Mock<IApiSpaceSpaceFeatureServerRequestModelValidator>();

		public Mock<IApiStudentServerRequestModelValidator> StudentModelValidatorMock { get; set; } = new Mock<IApiStudentServerRequestModelValidator>();

		public Mock<IApiStudioServerRequestModelValidator> StudioModelValidatorMock { get; set; } = new Mock<IApiStudioServerRequestModelValidator>();

		public Mock<IApiTeacherServerRequestModelValidator> TeacherModelValidatorMock { get; set; } = new Mock<IApiTeacherServerRequestModelValidator>();

		public Mock<IApiTeacherSkillServerRequestModelValidator> TeacherSkillModelValidatorMock { get; set; } = new Mock<IApiTeacherSkillServerRequestModelValidator>();

		public Mock<IApiTeacherTeacherSkillServerRequestModelValidator> TeacherTeacherSkillModelValidatorMock { get; set; } = new Mock<IApiTeacherTeacherSkillServerRequestModelValidator>();

		public Mock<IApiTenantServerRequestModelValidator> TenantModelValidatorMock { get; set; } = new Mock<IApiTenantServerRequestModelValidator>();

		public Mock<IApiUserServerRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventStudentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventStudentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStudentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStudentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStudentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventTeacherModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventTeacherModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventTeacherModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FamilyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FamilyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FamilyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpaceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpaceSpaceFeatureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceSpaceFeatureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceSpaceFeatureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StudentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StudioModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudioModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudioModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeacherModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeacherTeacherSkillModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherTeacherSkillModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherTeacherSkillModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TenantModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTenantServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>7cdfedaba5b41594c84a7d30c604e620</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/