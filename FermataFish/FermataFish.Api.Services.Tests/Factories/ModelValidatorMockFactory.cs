using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services.Tests
{
        public class ModelValidatorMockFactory
        {
                public Mock<IApiAdminRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminRequestModelValidator>();

                public Mock<IApiFamilyRequestModelValidator> FamilyModelValidatorMock { get; set; } = new Mock<IApiFamilyRequestModelValidator>();

                public Mock<IApiLessonRequestModelValidator> LessonModelValidatorMock { get; set; } = new Mock<IApiLessonRequestModelValidator>();

                public Mock<IApiLessonStatusRequestModelValidator> LessonStatusModelValidatorMock { get; set; } = new Mock<IApiLessonStatusRequestModelValidator>();

                public Mock<IApiLessonXStudentRequestModelValidator> LessonXStudentModelValidatorMock { get; set; } = new Mock<IApiLessonXStudentRequestModelValidator>();

                public Mock<IApiLessonXTeacherRequestModelValidator> LessonXTeacherModelValidatorMock { get; set; } = new Mock<IApiLessonXTeacherRequestModelValidator>();

                public Mock<IApiRateRequestModelValidator> RateModelValidatorMock { get; set; } = new Mock<IApiRateRequestModelValidator>();

                public Mock<IApiSpaceRequestModelValidator> SpaceModelValidatorMock { get; set; } = new Mock<IApiSpaceRequestModelValidator>();

                public Mock<IApiSpaceFeatureRequestModelValidator> SpaceFeatureModelValidatorMock { get; set; } = new Mock<IApiSpaceFeatureRequestModelValidator>();

                public Mock<IApiSpaceXSpaceFeatureRequestModelValidator> SpaceXSpaceFeatureModelValidatorMock { get; set; } = new Mock<IApiSpaceXSpaceFeatureRequestModelValidator>();

                public Mock<IApiStateRequestModelValidator> StateModelValidatorMock { get; set; } = new Mock<IApiStateRequestModelValidator>();

                public Mock<IApiStudentRequestModelValidator> StudentModelValidatorMock { get; set; } = new Mock<IApiStudentRequestModelValidator>();

                public Mock<IApiStudentXFamilyRequestModelValidator> StudentXFamilyModelValidatorMock { get; set; } = new Mock<IApiStudentXFamilyRequestModelValidator>();

                public Mock<IApiStudioRequestModelValidator> StudioModelValidatorMock { get; set; } = new Mock<IApiStudioRequestModelValidator>();

                public Mock<IApiTeacherRequestModelValidator> TeacherModelValidatorMock { get; set; } = new Mock<IApiTeacherRequestModelValidator>();

                public Mock<IApiTeacherSkillRequestModelValidator> TeacherSkillModelValidatorMock { get; set; } = new Mock<IApiTeacherSkillRequestModelValidator>();

                public Mock<IApiTeacherXTeacherSkillRequestModelValidator> TeacherXTeacherSkillModelValidatorMock { get; set; } = new Mock<IApiTeacherXTeacherSkillRequestModelValidator>();

                public ModelValidatorMockFactory()
                {
                        this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.FamilyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FamilyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FamilyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.LessonModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLessonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.LessonStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.LessonXStudentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonXStudentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonXStudentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.LessonXTeacherModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLessonXTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonXTeacherModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonXTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.LessonXTeacherModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.RateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.RateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.RateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SpaceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.SpaceXSpaceFeatureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceXSpaceFeatureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.SpaceXSpaceFeatureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StudentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StudentXFamilyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudentXFamilyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudentXFamilyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.StudioModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudioRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudioModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.StudioModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.TeacherModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.TeacherXTeacherSkillModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherXTeacherSkillModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherXTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.TeacherXTeacherSkillModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                }
        }
}

/*<Codenesium>
    <Hash>934e25e730ffbe5d563187e7a2853a9a</Hash>
</Codenesium>*/