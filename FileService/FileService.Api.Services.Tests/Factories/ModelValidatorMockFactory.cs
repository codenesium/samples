using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>01a9ce7cd67d2b546b982501ad21ea79</Hash>
</Codenesium>*/