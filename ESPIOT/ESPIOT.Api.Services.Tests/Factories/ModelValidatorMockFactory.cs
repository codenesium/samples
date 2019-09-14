using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiDeviceServerRequestModelValidator> DeviceModelValidatorMock { get; set; } = new Mock<IApiDeviceServerRequestModelValidator>();

		public Mock<IApiDeviceActionServerRequestModelValidator> DeviceActionModelValidatorMock { get; set; } = new Mock<IApiDeviceActionServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.DeviceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>16e99769790a6587c3989b5c294b3264</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/