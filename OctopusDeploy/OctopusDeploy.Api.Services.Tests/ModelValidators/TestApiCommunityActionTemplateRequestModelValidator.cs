using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
                        await validator.ValidateUpdateAsync(default(string), new ApiCommunityActionTemplateRequestModel());

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
                        await validator.ValidateUpdateAsync(default(string), new ApiCommunityActionTemplateRequestModel());

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
                        await validator.ValidateUpdateAsync(default(string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                private async void BeUniqueByExternalId_Create_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(new CommunityActionTemplate()));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByExternalId_Create_Not_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByExternalId_Update_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(new CommunityActionTemplate()));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                private async void BeUniqueByExternalId_Update_Not_Exists()
                {
                        Mock<ICommunityActionTemplateRepository> communityActionTemplateRepository = new Mock<ICommunityActionTemplateRepository>();
                        communityActionTemplateRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
                        var validator = new ApiCommunityActionTemplateRequestModelValidator(communityActionTemplateRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiCommunityActionTemplateRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>d64ff94695d03fc775334ba5f6d2c8ad</Hash>
</Codenesium>*/