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
        [Trait("Table", "DeploymentProcess")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeploymentProcessRequestModelValidatorTest
        {
                public ApiDeploymentProcessRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void OwnerId_Create_null()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Update_null()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Create_length()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 151));
                }

                [Fact]
                public async void OwnerId_Update_length()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentProcessRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 151));
                }

                [Fact]
                public async void OwnerId_Delete()
                {
                        Mock<IDeploymentProcessRepository> deploymentProcessRepository = new Mock<IDeploymentProcessRepository>();
                        deploymentProcessRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));

                        var validator = new ApiDeploymentProcessRequestModelValidator(deploymentProcessRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>7e012bfeb9849bcb6d3814d1e4c302d6</Hash>
</Codenesium>*/