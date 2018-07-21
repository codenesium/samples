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
        [Trait("Table", "ApiKey")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiApiKeyRequestModelValidatorTest
        {
                public ApiApiKeyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ApiKeyHashed_Create_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, new string('A', 201));
                }

                [Fact]
                public async void ApiKeyHashed_Update_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, new string('A', 201));
                }

                [Fact]
                public async void UserId_Create_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                public async void UserId_Update_length()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));

                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                private async void BeUniqueByApiKeyHashed_Create_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(new ApiKey()));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueByApiKeyHashed_Create_Not_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiApiKeyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueByApiKeyHashed_Update_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(new ApiKey()));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiApiKeyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }

                [Fact]
                private async void BeUniqueByApiKeyHashed_Update_Not_Exists()
                {
                        Mock<IApiKeyRepository> apiKeyRepository = new Mock<IApiKeyRepository>();
                        apiKeyRepository.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
                        var validator = new ApiApiKeyRequestModelValidator(apiKeyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiApiKeyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ApiKeyHashed, "A");
                }
        }
}

/*<Codenesium>
    <Hash>734b0f35d68bcade6eb74b9d11d34cdb</Hash>
</Codenesium>*/