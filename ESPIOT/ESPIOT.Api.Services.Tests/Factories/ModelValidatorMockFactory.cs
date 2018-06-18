using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;

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
    <Hash>9025ebc2939e31f90aadce3e8b20f6a2</Hash>
</Codenesium>*/