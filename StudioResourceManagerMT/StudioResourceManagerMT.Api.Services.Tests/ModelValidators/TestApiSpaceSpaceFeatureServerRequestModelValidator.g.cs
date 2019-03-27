using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpaceSpaceFeatureServerRequestModelValidatorTest
	{
		public ApiSpaceSpaceFeatureServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SpaceFeatureId_Create_Valid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceSpaceFeatureServerRequestModelValidator(spaceSpaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceSpaceFeatureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Create_Invalid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceSpaceFeatureServerRequestModelValidator(spaceSpaceFeatureRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpaceSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Valid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceSpaceFeatureServerRequestModelValidator(spaceSpaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceSpaceFeatureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Invalid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceSpaceFeatureServerRequestModelValidator(spaceSpaceFeatureRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpaceSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>0b9e894aff24c2e0b10c8d1e34784a67</Hash>
</Codenesium>*/