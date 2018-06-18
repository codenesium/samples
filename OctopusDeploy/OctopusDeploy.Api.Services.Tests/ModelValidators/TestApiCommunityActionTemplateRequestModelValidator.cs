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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCommunityActionTemplateRequestModelValidatorTest
        {
                public ApiCommunityActionTemplateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));

                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Create_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(new CommunityActionTemplate()));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Create_Not_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Update_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(new CommunityActionTemplate()));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueGetExternalId_Update_Not_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.GetExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>0375efc5327385c4d463bcdbd0f27bb8</Hash>
</Codenesium>*/