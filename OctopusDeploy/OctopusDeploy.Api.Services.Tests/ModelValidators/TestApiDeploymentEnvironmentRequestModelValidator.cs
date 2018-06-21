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
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeploymentEnvironmentRequestModelValidatorTest
        {
                public ApiDeploymentEnvironmentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentEnvironment()));

                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(new DeploymentEnvironment()));
                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(null));
                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(new DeploymentEnvironment()));
                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IDeploymentEnvironmentRepository> deploymentEnvironmentRepository = new Mock<IDeploymentEnvironmentRepository>();
                        deploymentEnvironmentRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(null));
                        var validator = new ApiDeploymentEnvironmentRequestModelValidator(deploymentEnvironmentRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentEnvironmentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>16e4a1080b6a60a5505bec4eaa2493e9</Hash>
</Codenesium>*/