using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services.Tests
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
    <Hash>666ba2aaaae746a87493722d42b73166</Hash>
</Codenesium>*/