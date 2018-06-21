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
        [Trait("Table", "DeploymentRelatedMachine")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeploymentRelatedMachineRequestModelValidatorTest
        {
                public ApiDeploymentRelatedMachineRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DeploymentId_Create_null()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, null as string);
                }

                [Fact]
                public async void DeploymentId_Update_null()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, null as string);
                }

                [Fact]
                public async void DeploymentId_Create_length()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, new string('A', 51));
                }

                [Fact]
                public async void DeploymentId_Update_length()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, new string('A', 51));
                }

                [Fact]
                public async void DeploymentId_Delete()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void DeploymentId_Create_Valid_Reference()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.GetDeployment(It.IsAny<string>())).Returns(Task.FromResult<Deployment>(new Deployment()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.DeploymentId, "A");
                }

                [Fact]
                public async void DeploymentId_Create_Invalid_Reference()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.GetDeployment(It.IsAny<string>())).Returns(Task.FromResult<Deployment>(null));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, "A");
                }

                [Fact]
                public async void DeploymentId_Update_Valid_Reference()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.GetDeployment(It.IsAny<string>())).Returns(Task.FromResult<Deployment>(new Deployment()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.DeploymentId, "A");
                }

                [Fact]
                public async void DeploymentId_Update_Invalid_Reference()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.GetDeployment(It.IsAny<string>())).Returns(Task.FromResult<Deployment>(null));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeploymentId, "A");
                }

                [Fact]
                public async void MachineId_Create_null()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, null as string);
                }

                [Fact]
                public async void MachineId_Update_null()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, null as string);
                }

                [Fact]
                public async void MachineId_Create_length()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, new string('A', 51));
                }

                [Fact]
                public async void MachineId_Update_length()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiDeploymentRelatedMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MachineId, new string('A', 51));
                }

                [Fact]
                public async void MachineId_Delete()
                {
                        Mock<IDeploymentRelatedMachineRepository> deploymentRelatedMachineRepository = new Mock<IDeploymentRelatedMachineRepository>();
                        deploymentRelatedMachineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));

                        var validator = new ApiDeploymentRelatedMachineRequestModelValidator(deploymentRelatedMachineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>35ec8c8b82d3e71922d8d257afbff7f2</Hash>
</Codenesium>*/