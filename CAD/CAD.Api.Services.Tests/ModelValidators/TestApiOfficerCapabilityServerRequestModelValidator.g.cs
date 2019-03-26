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
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOfficerCapabilityServerRequestModelValidatorTest
	{
		public ApiOfficerCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);

			await validator.ValidateCreateAsync(new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>1bbb67fb6f18341f1be508ad6c337775</Hash>
</Codenesium>*/