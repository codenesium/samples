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
        [Trait("Table", "Configuration")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiConfigurationRequestModelValidatorTest
        {
                public ApiConfigurationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IConfigurationRepository> configurationRepository = new Mock<IConfigurationRepository>();
                        configurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Configuration()));

                        var validator = new ApiConfigurationRequestModelValidator(configurationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IConfigurationRepository> configurationRepository = new Mock<IConfigurationRepository>();
                        configurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Configuration()));

                        var validator = new ApiConfigurationRequestModelValidator(configurationRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>e38137aea543c547fffdf9c48e1a9953</Hash>
</Codenesium>*/