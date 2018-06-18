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
        [Trait("Table", "Proxy")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProxyRequestModelValidatorTest
        {
                public ApiProxyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(new Proxy()));
                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProxyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(new Proxy()));
                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProxyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
                        proxyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
                        var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiProxyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>1aaca5138e58d504a3333f5f311c0d08</Hash>
</Codenesium>*/