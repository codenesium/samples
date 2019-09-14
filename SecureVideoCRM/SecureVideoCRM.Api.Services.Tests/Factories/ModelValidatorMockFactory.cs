using Moq;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiVideoServerRequestModelValidator> VideoModelValidatorMock { get; set; } = new Mock<IApiVideoServerRequestModelValidator>();

		public Mock<IApiUserServerRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserServerRequestModelValidator>();

		public Mock<IApiSubscriptionServerRequestModelValidator> SubscriptionModelValidatorMock { get; set; } = new Mock<IApiSubscriptionServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.VideoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVideoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VideoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVideoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VideoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSubscriptionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>8d13b4ed406ecd97cfd71d058e9f917d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/