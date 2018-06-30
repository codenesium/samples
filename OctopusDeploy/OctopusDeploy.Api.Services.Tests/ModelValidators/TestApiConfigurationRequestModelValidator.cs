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
                        await validator.ValidateUpdateAsync(default(string), new ApiConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>05a9ab6a5782e2a9b335601a99848a6d</Hash>
</Codenesium>*/