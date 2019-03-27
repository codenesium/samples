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
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOfficerCapabilitiesServerRequestModelValidatorTest
	{
		public ApiOfficerCapabilitiesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CapabilityId_Create_Valid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OffCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OffCapability>(new OffCapability()));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Create_Invalid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OffCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OffCapability>(null));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);

			await validator.ValidateCreateAsync(new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Update_Valid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OffCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OffCapability>(new OffCapability()));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Update_Invalid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OffCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OffCapability>(null));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);

			await validator.ValidateCreateAsync(new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<IOfficerCapabilitiesRepository> officerCapabilitiesRepository = new Mock<IOfficerCapabilitiesRepository>();
			officerCapabilitiesRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerCapabilitiesServerRequestModelValidator(officerCapabilitiesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>d2c947557bcdca2eff603cea0e4d8413</Hash>
</Codenesium>*/