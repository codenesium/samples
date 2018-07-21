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
        [Trait("Table", "SpaceFeature")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSpaceFeatureRequestModelValidatorTest
        {
                public ApiSpaceFeatureRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void StudioId_Create_Valid_Reference()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceFeatureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Create_Invalid_Reference()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Valid_Reference()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>0f99abea8a1fe087918596f70105f9af</Hash>
</Codenesium>*/