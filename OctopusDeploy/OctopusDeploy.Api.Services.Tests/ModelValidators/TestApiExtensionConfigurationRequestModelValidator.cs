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
        [Trait("Table", "ExtensionConfiguration")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiExtensionConfigurationRequestModelValidatorTest
        {
                public ApiExtensionConfigurationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ExtensionAuthor_Create_length()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExtensionAuthor, new string('A', 1001));
                }

                [Fact]
                public async void ExtensionAuthor_Update_length()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExtensionAuthor, new string('A', 1001));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 1001));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IExtensionConfigurationRepository> extensionConfigurationRepository = new Mock<IExtensionConfigurationRepository>();
                        extensionConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));

                        var validator = new ApiExtensionConfigurationRequestModelValidator(extensionConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiExtensionConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 1001));
                }
        }
}

/*<Codenesium>
    <Hash>86033326099c36ad45753fe0de27fab7</Hash>
</Codenesium>*/