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
		public async void Name_Create_null()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IOfficerCapabilityRepository> officerCapabilityRepository = new Mock<IOfficerCapabilityRepository>();
			officerCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OfficerCapability()));

			var validator = new ApiOfficerCapabilityServerRequestModelValidator(officerCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>e0d491197f08df207c5201000cb0be27</Hash>
</Codenesium>*/