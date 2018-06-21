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
        [Trait("Table", "Deployment")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDeploymentRequestModelValidatorTest
        {
                public ApiDeploymentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ChannelId_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, null as string);
                }

                [Fact]
                public async void ChannelId_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, null as string);
                }

                [Fact]
                public async void ChannelId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ChannelId, new string('A', 51));
                }

                [Fact]
                public async void ChannelId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void DeployedBy_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, null as string);
                }

                [Fact]
                public async void DeployedBy_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, null as string);
                }

                [Fact]
                public async void DeployedBy_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, new string('A', 201));
                }

                [Fact]
                public async void DeployedBy_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DeployedBy, new string('A', 201));
                }

                [Fact]
                public async void DeployedBy_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EnvironmentId_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, null as string);
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectGroupId_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, null as string);
                }

                [Fact]
                public async void ProjectGroupId_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, null as string);
                }

                [Fact]
                public async void ProjectGroupId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, new string('A', 51));
                }

                [Fact]
                public async void ProjectGroupId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectGroupId, new string('A', 51));
                }

                [Fact]
                public async void ProjectGroupId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ReleaseId_Create_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, null as string);
                }

                [Fact]
                public async void ReleaseId_Update_null()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, null as string);
                }

                [Fact]
                public async void ReleaseId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, new string('A', 51));
                }

                [Fact]
                public async void ReleaseId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ReleaseId, new string('A', 51));
                }

                [Fact]
                public async void ReleaseId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TaskId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDeploymentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<IDeploymentRepository> deploymentRepository = new Mock<IDeploymentRepository>();
                        deploymentRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Deployment()));

                        var validator = new ApiDeploymentRequestModelValidator(deploymentRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>c96c32b86cac98d01438e827fbc367bd</Hash>
</Codenesium>*/