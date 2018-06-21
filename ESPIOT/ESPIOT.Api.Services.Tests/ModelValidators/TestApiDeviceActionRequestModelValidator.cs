using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeviceAction")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeviceActionRequestModelValidatorTest
        {
                public ApiDeviceActionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DeviceId_Create_Valid_Reference()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.GetDevice(It.IsAny<int>())).Returns(Task.FromResult<Device>(new Device()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.DeviceId, 1);
                }

                [Fact]
                public async void DeviceId_Create_Invalid_Reference()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.GetDevice(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeviceId, 1);
                }

                [Fact]
                public async void DeviceId_Update_Valid_Reference()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.GetDevice(It.IsAny<int>())).Returns(Task.FromResult<Device>(new Device()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.DeviceId, 1);
                }

                [Fact]
                public async void DeviceId_Update_Invalid_Reference()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.GetDevice(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeviceId, 1);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void @Value_Create_null()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Value, null as string);
                }

                [Fact]
                public async void @Value_Update_null()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Value, null as string);
                }

                [Fact]
                public async void @Value_Create_length()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Value, new string('A', 4001));
                }

                [Fact]
                public async void @Value_Update_length()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Value, new string('A', 4001));
                }

                [Fact]
                public async void @Value_Delete()
                {
                        Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
                        deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

                        var validator = new ApiDeviceActionRequestModelValidator(deviceActionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>38388d0c53d647348372ac1bbcfa6d83</Hash>
</Codenesium>*/