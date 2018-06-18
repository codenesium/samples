using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        public class ModelValidatorMockFactory
        {
                public Mock<IApiBucketRequestModelValidator> BucketModelValidatorMock { get; set; } = new Mock<IApiBucketRequestModelValidator>();

                public Mock<IApiFileRequestModelValidator> FileModelValidatorMock { get; set; } = new Mock<IApiFileRequestModelValidator>();

                public Mock<IApiFileTypeRequestModelValidator> FileTypeModelValidatorMock { get; set; } = new Mock<IApiFileTypeRequestModelValidator>();

                public Mock<IApiVersionInfoRequestModelValidator> VersionInfoModelValidatorMock { get; set; } = new Mock<IApiVersionInfoRequestModelValidator>();

                public ModelValidatorMockFactory()
                {
                        this.BucketModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBucketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BucketModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.BucketModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.FileModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FileModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FileModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.FileTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FileTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.FileTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

                        this.VersionInfoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.VersionInfoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                        this.VersionInfoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
                }
        }
}

/*<Codenesium>
    <Hash>d945f08ffc664380df0264a909921226</Hash>
</Codenesium>*/