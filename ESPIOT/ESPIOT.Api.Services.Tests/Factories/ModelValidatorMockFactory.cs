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
		public Mock<IApiDeviceRequestModelValidator> DeviceModelValidatorMock { get; set; } = new Mock<IApiDeviceRequestModelValidator>();

		public Mock<IApiDeviceActionRequestModelValidator> DeviceActionModelValidatorMock { get; set; } = new Mock<IApiDeviceActionRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.DeviceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeviceActionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>ae231d90e98b3d24322d96eddf39d6b0</Hash>
</Codenesium>*/