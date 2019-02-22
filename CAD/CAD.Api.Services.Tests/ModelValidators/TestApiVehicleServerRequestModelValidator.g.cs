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
	[Trait("Table", "Vehicle")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleServerRequestModelValidatorTest
	{
		public ApiVehicleServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
			vehicleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));

			var validator = new ApiVehicleServerRequestModelValidator(vehicleRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
			vehicleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));

			var validator = new ApiVehicleServerRequestModelValidator(vehicleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
			vehicleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));

			var validator = new ApiVehicleServerRequestModelValidator(vehicleRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehicleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVehicleRepository> vehicleRepository = new Mock<IVehicleRepository>();
			vehicleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vehicle()));

			var validator = new ApiVehicleServerRequestModelValidator(vehicleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehicleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>17282aefcd2f3c3b1e51a450c338104c</Hash>
</Codenesium>*/