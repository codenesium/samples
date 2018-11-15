using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using StudioResourceManagerMTNS.Api.Contracts; 
using StudioResourceManagerMTNS.Api.DataAccess; 

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
							validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A',129));
						}

						[Fact]
						public async void Name_Update_length()
						{	
							Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

							var validator = new ApiSpaceFeatureServerRequestModelValidator(spaceFeatureRepository.Object);
							await validator.ValidateUpdateAsync(default(int),new ApiSpaceFeatureServerRequestModel());
							validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A',129));
						}

				





	  

    }
}

/*<Codenesium>
    <Hash>fd3d90a2686a9b3182e2cb142157d309</Hash>
</Codenesium>*/