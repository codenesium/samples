using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpaceFeatureServerRequestModelValidatorTest
	{
		public ApiSpaceFeatureServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
			spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

			var validator = new ApiSpaceFeatureServerRequestModelValidator(spaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
			spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

			var validator = new ApiSpaceFeatureServerRequestModelValidator(spaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
			spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

			var validator = new ApiSpaceFeatureServerRequestModelValidator(spaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
			spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

			var validator = new ApiSpaceFeatureServerRequestModelValidator(spaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceFeatureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>30e99cdfe9a9bfe689348471db0db123</Hash>
</Codenesium>*/