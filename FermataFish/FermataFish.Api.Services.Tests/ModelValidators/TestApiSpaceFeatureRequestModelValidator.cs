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
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
                public async void Name_Create_null()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
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

                        await validator.ValidateUpdateAsync(default (int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
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

                        await validator.ValidateUpdateAsync(default (int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ISpaceFeatureRepository> spaceFeatureRepository = new Mock<ISpaceFeatureRepository>();
                        spaceFeatureRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiSpaceFeatureRequestModelValidator(spaceFeatureRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSpaceFeatureRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>c489dcbe70758c91f44fe4572ab3b46e</Hash>
</Codenesium>*/