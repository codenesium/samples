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
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOfficerRefCapabilityServerRequestModelValidatorTest
	{
		public ApiOfficerRefCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CapabilityId_Create_Valid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapability>(new OfficerCapability()));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Create_Invalid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapability>(null));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);

			await validator.ValidateCreateAsync(new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Update_Valid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapability>(new OfficerCapability()));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void CapabilityId_Update_Invalid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerCapabilityByCapabilityId(It.IsAny<int>())).Returns(Task.FromResult<OfficerCapability>(null));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CapabilityId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);

			await validator.ValidateCreateAsync(new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<IOfficerRefCapabilityRepository> officerRefCapabilityRepository = new Mock<IOfficerRefCapabilityRepository>();
			officerRefCapabilityRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiOfficerRefCapabilityServerRequestModelValidator(officerRefCapabilityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>0a75183e402a16d185aa9a9e892b19a3</Hash>
</Codenesium>*/