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
    <Hash>d485054df93f4d1b5df9a5a26607c7c2</Hash>
</Codenesium>*/