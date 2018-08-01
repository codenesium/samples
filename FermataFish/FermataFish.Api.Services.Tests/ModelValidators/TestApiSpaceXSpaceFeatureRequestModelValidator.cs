using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceXSpaceFeature")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpaceXSpaceFeatureRequestModelValidatorTest
	{
		public ApiSpaceXSpaceFeatureRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SpaceFeatureId_Create_Valid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpaceFeature(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Create_Invalid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpaceFeature(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Valid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpaceFeature(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Invalid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpaceFeature(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceId_Create_Valid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpace(It.IsAny<int>())).Returns(Task.FromResult<Space>(new Space()));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceId, 1);
		}

		[Fact]
		public async void SpaceId_Create_Invalid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpace(It.IsAny<int>())).Returns(Task.FromResult<Space>(null));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceId, 1);
		}

		[Fact]
		public async void SpaceId_Update_Valid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpace(It.IsAny<int>())).Returns(Task.FromResult<Space>(new Space()));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceId, 1);
		}

		[Fact]
		public async void SpaceId_Update_Invalid_Reference()
		{
			Mock<ISpaceXSpaceFeatureRepository> spaceXSpaceFeatureRepository = new Mock<ISpaceXSpaceFeatureRepository>();
			spaceXSpaceFeatureRepository.Setup(x => x.GetSpace(It.IsAny<int>())).Returns(Task.FromResult<Space>(null));

			var validator = new ApiSpaceXSpaceFeatureRequestModelValidator(spaceXSpaceFeatureRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>02877fc0f6e072d843e05b358b394914</Hash>
</Codenesium>*/