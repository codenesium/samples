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
	public partial class ApiDeviceActionServerRequestModelValidatorTest
	{
		public ApiDeviceActionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Action_Create_null()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Action, null as string);
		}

		[Fact]
		public async void Action_Update_null()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Action, null as string);
		}

		[Fact]
		public async void Action_Create_length()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Action, new string('A', 4001));
		}

		[Fact]
		public async void Action_Update_length()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Action, new string('A', 4001));
		}

		[Fact]
		public async void DeviceId_Create_Valid_Reference()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.DeviceByDeviceId(It.IsAny<int>())).Returns(Task.FromResult<Device>(new Device()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DeviceId, 1);
		}

		[Fact]
		public async void DeviceId_Create_Invalid_Reference()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.DeviceByDeviceId(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);

			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DeviceId, 1);
		}

		[Fact]
		public async void DeviceId_Update_Valid_Reference()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.DeviceByDeviceId(It.IsAny<int>())).Returns(Task.FromResult<Device>(new Device()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DeviceId, 1);
		}

		[Fact]
		public async void DeviceId_Update_Invalid_Reference()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.DeviceByDeviceId(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DeviceId, 1);
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateCreateAsync(new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IDeviceActionRepository> deviceActionRepository = new Mock<IDeviceActionRepository>();
			deviceActionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));

			var validator = new ApiDeviceActionServerRequestModelValidator(deviceActionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDeviceActionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 91));
		}
	}
}

/*<Codenesium>
    <Hash>14de6c7070bf94b657702ca64de533ba</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/