using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleRefCapabilityServerRequestModelValidatorTest
	{
		public ApiVehicleRefCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void VehicleCapabilityId_Create_Valid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapability>(new VehicleCapability()));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Create_Invalid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapability>(null));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Update_Valid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapability>(new VehicleCapability()));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Update_Invalid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehicleCapability>(null));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Valid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Invalid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Valid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Invalid_Reference()
		{
			Mock<IVehicleRefCapabilityRepository> vehicleRefCapabilityRepository = new Mock<IVehicleRefCapabilityRepository>();
			vehicleRefCapabilityRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleRefCapabilityServerRequestModelValidator(vehicleRefCapabilityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>006dd90ccc2153e3815471e011bd98c4</Hash>
</Codenesium>*/