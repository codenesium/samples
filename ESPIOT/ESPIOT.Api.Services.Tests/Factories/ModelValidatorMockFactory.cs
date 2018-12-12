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
		public Mock<IApiEfmigrationshistoryServerRequestModelValidator> EfmigrationshistoryModelValidatorMock { get; set; } = new Mock<IApiEfmigrationshistoryServerRequestModelValidator>();

		public Mock<IApiDeviceServerRequestModelValidator> DeviceModelValidatorMock { get; set; } = new Mock<IApiDeviceServerRequestModelValidator>();

		public Mock<IApiDeviceActionServerRequestModelValidator> DeviceActionModelValidatorMock { get; set; } = new Mock<IApiDeviceActionServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.EfmigrationshistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EfmigrationshistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EfmigrationshistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

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
    <Hash>820fa015c02b3507d676008a6247f7bf</Hash>
</Codenesium>*/