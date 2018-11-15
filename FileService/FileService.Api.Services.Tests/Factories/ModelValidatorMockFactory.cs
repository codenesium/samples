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
		public Mock<IApiBucketServerRequestModelValidator> BucketModelValidatorMock { get; set; } = new Mock<IApiBucketServerRequestModelValidator>();

		public Mock<IApiFileServerRequestModelValidator> FileModelValidatorMock { get; set; } = new Mock<IApiFileServerRequestModelValidator>();

		public Mock<IApiFileTypeServerRequestModelValidator> FileTypeModelValidatorMock { get; set; } = new Mock<IApiFileTypeServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BucketModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBucketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BucketModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BucketModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FileModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FileModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FileModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FileTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FileTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FileTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>8b88e90ac9eaffabf2df1b59d0e258a0</Hash>
</Codenesium>*/