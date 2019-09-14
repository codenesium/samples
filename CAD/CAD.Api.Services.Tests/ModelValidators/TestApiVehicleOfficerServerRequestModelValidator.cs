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
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleOfficerServerRequestModelValidatorTest
	{
		public ApiVehicleOfficerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Valid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Create_Invalid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);

			await validator.ValidateCreateAsync(new ApiVehicleOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Valid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(new Vehicle()));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VehicleId, 1);
		}

		[Fact]
		public async void VehicleId_Update_Invalid_Reference()
		{
			Mock<IVehicleOfficerRepository> vehicleOfficerRepository = new Mock<IVehicleOfficerRepository>();
			vehicleOfficerRepository.Setup(x => x.VehicleByVehicleId(It.IsAny<int>())).Returns(Task.FromResult<Vehicle>(null));

			var validator = new ApiVehicleOfficerServerRequestModelValidator(vehicleOfficerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVehicleOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VehicleId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>dd4d1f2b69b196f1571a7a1781c473ae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/