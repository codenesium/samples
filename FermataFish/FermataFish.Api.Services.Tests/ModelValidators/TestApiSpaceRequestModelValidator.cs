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
        [Trait("Table", "Space")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSpaceRequestModelValidatorTest
        {
                public ApiSpaceRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Create_length()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
                }

                [Fact]
                public async void Description_Update_length()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void StudioId_Create_Valid_Reference()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Create_Invalid_Reference()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Valid_Reference()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
                }

                [Fact]
                public async void StudioId_Update_Invalid_Reference()
                {
                        Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
                        spaceRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

                        var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>5dd0b8f883a39001341d7708a56f0d4b</Hash>
</Codenesium>*/