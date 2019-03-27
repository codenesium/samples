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
	[Trait("Table", "VehCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehCapabilityServerRequestModelValidatorTest
	{
		public ApiVehCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVehCapabilityRepository> vehCapabilityRepository = new Mock<IVehCapabilityRepository>();
			vehCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));

			var validator = new ApiVehCapabilityServerRequestModelValidator(vehCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVehCapabilityRepository> vehCapabilityRepository = new Mock<IVehCapabilityRepository>();
			vehCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));

			var validator = new ApiVehCapabilityServerRequestModelValidator(vehCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVehCapabilityRepository> vehCapabilityRepository = new Mock<IVehCapabilityRepository>();
			vehCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));

			var validator = new ApiVehCapabilityServerRequestModelValidator(vehCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiVehCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVehCapabilityRepository> vehCapabilityRepository = new Mock<IVehCapabilityRepository>();
			vehCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VehCapability()));

			var validator = new ApiVehCapabilityServerRequestModelValidator(vehCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVehCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>137864eb3f6a5674ee94c98c9b271bcb</Hash>
</Codenesium>*/