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
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpaceSpaceFeatureRequestModelValidatorTest
	{
		public ApiSpaceSpaceFeatureRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= SpaceFeature
		[Fact]
		public async void SpaceFeatureId_Create_Valid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceSpaceFeatureRequestModelValidator(spaceSpaceFeatureRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Create_Invalid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceSpaceFeatureRequestModelValidator(spaceSpaceFeatureRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpaceSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Valid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(new SpaceFeature()));

			var validator = new ApiSpaceSpaceFeatureRequestModelValidator(spaceSpaceFeatureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceSpaceFeatureRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}

		[Fact]
		public async void SpaceFeatureId_Update_Invalid_Reference()
		{
			Mock<ISpaceSpaceFeatureRepository> spaceSpaceFeatureRepository = new Mock<ISpaceSpaceFeatureRepository>();
			spaceSpaceFeatureRepository.Setup(x => x.SpaceFeatureBySpaceFeatureId(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));

			var validator = new ApiSpaceSpaceFeatureRequestModelValidator(spaceSpaceFeatureRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpaceSpaceFeatureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SpaceFeatureId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>f7a5e591ca09fef92a6a3ffc0881080f</Hash>
</Codenesium>*/