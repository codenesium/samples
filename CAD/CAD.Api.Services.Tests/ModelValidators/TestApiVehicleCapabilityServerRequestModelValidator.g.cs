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
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleCapabilityServerRequestModelValidatorTest
	{
		public ApiVehicleCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVehicleCapabilityRepository> vehicleCapabilityRepository = new Mock<IVehicleCapabilityRepository>();
			vehicleCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));

			var validator = new ApiVehicleCapabilityServerRequestModelValidator(vehicleCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVehicleCapabilityRepository> vehicleCapabilityRepository = new Mock<IVehicleCapabilityRepository>();
			vehicleCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));

			var validator = new ApiVehicleCapabilityServerRequestModelValidator(vehicleCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVehicleCapabilityRepository> vehicleCapabilityRepository = new Mock<IVehicleCapabilityRepository>();
			vehicleCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));

			var validator = new ApiVehicleCapabilityServerRequestModelValidator(vehicleCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVehicleCapabilityRepository> vehicleCapabilityRepository = new Mock<IVehicleCapabilityRepository>();
			vehicleCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehicleCapability()));

			var validator = new ApiVehicleCapabilityServerRequestModelValidator(vehicleCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>44e301b33a00de9ac1860e7dca047d97</Hash>
</Codenesium>*/