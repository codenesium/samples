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
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleCapabilitiesServerRequestModelValidatorTest
	{
		public ApiVehicleCapabilitiesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void VehicleCapabilityId_Create_Valid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehCapability>(new VehCapability()));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Create_Invalid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehCapability>(null));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Update_Valid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehCapability>(new VehCapability()));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleCapabilityId_Update_Invalid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehCapabilityByVehicleCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<VehCapability>(null));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleCapabilityId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Valid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Invalid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Valid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Invalid_Reference()
		{
			Mock<IVehicleCapabilitiesRepository> vehicleCapabilitiesRepository = new Mock<IVehicleCapabilitiesRepository>();
			vehicleCapabilitiesRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleCapabilitiesServerRequestModelValidator(vehicleCapabilitiesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3ec69c62f510c780447cd6dd1dd770a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/